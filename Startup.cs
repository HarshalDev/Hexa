using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReSaleCarBuyerAPI.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

namespace ReSaleCarBuyerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ReSaleCarBuyerDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });

            services.AddCors(c =>
            {
                c.AddPolicy("ResaleCarBuyerAPI", config =>
                {
                    config.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    //.WithHeaders("content-type", "Accept", "Authorization")
                    //.WithMethods("get", "post", "put", "delete");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "ReSaleCar Buyer API",
                    Description = "Contains the API operation for adding, deleting, and querying Cars",
                    Version = "1.0",
                    Contact = new Contact { Name = "Hexaware", Email = "48058@hexaware.com" }
                });
            });

            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(c =>
            {
                c.RequireHttpsMetadata = false;
                c.SaveToken = true;
                c.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration.GetValue<string>("Jwt:Issuer"),
                    ValidAudience = Configuration.GetValue<string>("Jwt:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:Secret")))
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReSaleCar Buyer API");
                    c.RoutePrefix = string.Empty;
                });
            }
            InitializeDatabase(app);
            app.UseAuthentication();
            app.UseSwagger();
            app.UseCors(Configuration.GetValue<string>("CORSPolicyName"));
            app.UseMvc(opt =>
            {
                opt.MapRoute("Default",
                    "{controller=Buyers}/{action=CarSellerDetails}/{id?}");
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<ReSaleCarBuyerDbContext>())
                {
                    dbContext.Database.Migrate();
                }
            }
        }
    }
}
