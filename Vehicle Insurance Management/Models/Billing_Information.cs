using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Insurance_Management.Models
{
    public class BillingInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillNo { get; set; }

        [ForeignKey("Customer")]
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer_Information Customer { get; set; }

        [Required]
        public string Policynumber { get; set; }

        [ForeignKey("Vehicle")]
        [Required]
        public int VehicleId { get; set; }
        public virtual Vehicle_Information Vehicle { get; set; }

        [Required]
        public string CustomerAddProof { get; set; }

        [Required]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Invalid phone number.")]
        public string CustomerPhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string CustomerEmail { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }
    }
}
