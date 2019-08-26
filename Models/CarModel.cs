using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReSaleCarBuyerAPI.Models
{
    [Table("CarDetails")]
    public class CarModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Min 2 and maximum 20 charcters required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SellingPrice is required")]
        public double SellingPrice { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
