using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReSaleCarBuyerAPI.Models
{
    [Table("BuyerDetails")]
    public class BuyerDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "SellerName is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Min 2 and maximum 20 charcters required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Min 2 and maximum 20 charcters required")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual CarModel CarModel { get; set; }
    }
}
