using System.ComponentModel.DataAnnotations;

namespace EcommerceShop.Models
{
    public class Addpolicytype
    {
        [Key]
        public int id { get; set; }

        [Required]
        public required string policy_name { get; set; }
    }
}
