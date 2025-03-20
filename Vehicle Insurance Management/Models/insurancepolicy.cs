using EcommerceShop.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Insurance_Management.Models
{
    public class insurancepolicy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string PolicyName { get; set; }
        [Required]
        public int PolicyType { get; set; }
        [Required]
        public required string PolicyDescription { get; set; }
        [Required]
        public required string PolicyImages { get; set; }
        [ForeignKey("PolicyType")]
        public required virtual Addpolicytype Addpolicytype { get; set; }

    }
}
