using System.ComponentModel.DataAnnotations;

namespace Vehicle_Insurance_Management.Models
{
    public class Vehicle_Information
    {
        [Key]
        public int VehicleId { get; set; }
        public int Login_Id { get; set; }

        [Required(ErrorMessage = "Vehicle name is required.")]
        [StringLength(100, ErrorMessage = "Vehicle name cannot exceed 100 characters.")]
        public string VehicleName { get; set; }

        [StringLength(100, ErrorMessage = "Owner name cannot exceed 100 characters.")]
        [Required(ErrorMessage = "Owner name is required.")]
        public string OwnerName { get; set; } 

        [Required(ErrorMessage = "Vehicle model is required.")]
        [StringLength(50, ErrorMessage = "Model name cannot exceed 50 characters.")]
        public string Model { get; set; } 

        [Required(ErrorMessage = "Vehicle version is required.")]
        [StringLength(50, ErrorMessage = "Version cannot exceed 50 characters.")]
        public string Version { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Rate must be a positive number.")]

        [Required(ErrorMessage = "Vehicle rate is required.")]
        public int Rate { get; set; } 

        [Required(ErrorMessage = "Body number is required.")]
        [StringLength(50, ErrorMessage = "Body number cannot exceed 50 characters.")]
        public string BodyNumber { get; set; } 

        [Required(ErrorMessage = "Engine number is required.")]
        [StringLength(50, ErrorMessage = "Engine number cannot exceed 50 characters.")]
        public string EngineNumber { get; set; }

        [Required(ErrorMessage = "Vehicle number is required.")]
        [RegularExpression(@"^[A-Z0-9-]+$", ErrorMessage = "Invalid vehicle number format.")]
        public int VehicleNumber { get; set; } 
    }
}
