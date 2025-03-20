using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Insurance_Management.Models
{
    public class insurance_process
    {
        [Key]
        public int InsuranceId { get; set; }

        public int Login_Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer_Information Customer { get; set; }


        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle_Information Vehicle { get; set; }

        [Required(ErrorMessage = "Policy number is required.")]
        public int PolicyNumber { get; set; }

        [Required(ErrorMessage = "Policy date is required.")]
        public DateTime PolicyDate { get; set; }

        [Required(ErrorMessage = "Policy duration is required.")]
        public int PolicyDuration { get; set; } 
    }
}
