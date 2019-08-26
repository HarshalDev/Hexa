using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReSaleCarBuyerAPI.Models
{
    [Table("Manufacturer")]
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Manufacturer name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Min 2 and maximum 20 charcters required")]
        public string Name { get; set; }

        public virtual ICollection<CarModel> CarModel { get; set; }
    }
}
