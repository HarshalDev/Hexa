using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReSaleCarBuyerAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ReSaleCarBuyerAPI.Infrastructure
{
    public class BusinessLayer
    {
        private readonly ReSaleCarBuyerDbContext _context;
        public BusinessLayer(ReSaleCarBuyerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BuyerDTO>> GetSellerDetails()
        {
            var result = _context.Buyers.Select(c => new BuyerDTO
            {
                ContactNo = c.ContactNo,
                Email = c.Email,
                Id = c.Id,
                Name = c.Name
            });

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<ManufacturerDTO>> GetManufacturerDto()
        {
            var result = _context.Manufacturers.Select(c => new ManufacturerDTO
            {
                Id = c.Id,
                Name = c.Name
            });

            return await result.ToListAsync();
        }
    }
}
