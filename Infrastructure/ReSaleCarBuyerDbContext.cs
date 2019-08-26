using Microsoft.EntityFrameworkCore;
using ReSaleCarBuyerAPI.Models;

namespace ReSaleCarBuyerAPI.Infrastructure
{
    public class ReSaleCarBuyerDbContext: DbContext
    {
        public ReSaleCarBuyerDbContext(DbContextOptions<ReSaleCarBuyerDbContext> options) : base(options)
        {

        }

        public DbSet<BuyerDetails> Buyers { get; set; }

        public DbSet<CarModel> CarDetails { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
