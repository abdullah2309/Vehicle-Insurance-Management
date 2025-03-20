using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Insurance_Management.Models
{
    public class Estimate
    {
        [Key]
        public int EstimateId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; } // Foreign Key

        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
        public decimal VehicleRate { get; set; }
        public string VehicleWarranty { get; set; }
        public string VehiclePolicyType { get; set; }

        public Customer_Information Customer { get; set; } // Navigation Property
    }

}
