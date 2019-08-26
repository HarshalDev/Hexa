using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReSaleCarBuyerAPI.DTOs
{
    public class CarDetailsDTO
    {
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public double SellingPrice { get; set; }
    }
}
