using System.ComponentModel.DataAnnotations;

namespace Vehicle_Insurance_Management.Models
{
    public class Customer_Information
    {
        [Key]
        public int Id { get; set; }
        public int Login_Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}-\d{7}-\d{1}$", ErrorMessage = "Invalid CNIC format (e.g., 12345-1234567-1).")]
        public string CNIC { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public DateTime DateOfExpiry { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Sex { get; set; }  // Male or Female
    }
}
