using System.ComponentModel.DataAnnotations;

namespace Vehicle_Insurance_Management.Models
{
    public class SignUp
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string User_Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format. Example: email123@email.com")]
        public required string User_Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,20}$",
            ErrorMessage = "Password must be 8 to 20 characters long and contain at least one digit, one uppercase letter, and one lowercase letter.")]
        public required string User_Password { get; set; }
    }
}
