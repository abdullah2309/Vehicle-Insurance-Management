using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Insurance_Management.Models
{
    public class ClaimDetails
    {
        [Key]
        public int ClaimNumber { get; set; } // Primary Key

        [Required]
        public int PolicyNumber { get; set; } // Foreign Key referencing Policy
        [ForeignKey("PolicyNumber")]
        public virtual insurancepolicy Insurancepolicy  { get; set; }

        [Required]
        public string PolicyStartDate { get; set; }

        [Required]
        public string PolicyEndDate { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string PlaceOfAccident { get; set; }

        [Required]
        public DateTime DateOfAccident { get; set; }

        [Required]
        public decimal InsuredAmount { get; set; }

        [Required]
        public decimal ClaimableAmount { get; set; }
    }
}
