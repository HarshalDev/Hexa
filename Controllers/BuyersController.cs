using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReSaleCarBuyerAPI.DTOs;
using ReSaleCarBuyerAPI.Infrastructure;

namespace ReSaleCarBuyerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        private readonly ReSaleCarBuyerDbContext _context;
        private readonly BusinessLayer _businessLayer;
        public BuyersController(ReSaleCarBuyerDbContext context)
        {
            _context = context;
            _businessLayer = new BusinessLayer(_context);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet]
        //[ActionName("Sellerdetails")]
        public async Task<IEnumerable<BuyerDTO>> CarSellerDetails()
        {
            return await _businessLayer.GetSellerDetails();
        }

        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[HttpGet]
        ////[ActionName("Manufacturerdetails")]
        //public async Task<IEnumerable<ManufacturerDTO>> ManufacturerDetails()
        //{
        //    return await _businessLayer.GetManufacturerDto();
        //}
    }
}