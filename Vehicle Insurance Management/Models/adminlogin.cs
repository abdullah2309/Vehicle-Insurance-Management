using System.ComponentModel.DataAnnotations;

namespace EcommerceShop.Models
{
    public class adminlogin
    {
        [Key]
       public int Id { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}
