using System;
using System.ComponentModel.DataAnnotations;

namespace Vehicle_Insurance_Management.Models
{
    public class CompanyExpenses
    {
        [Key]
        public int ExpenseId { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfExpense { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Expense type cannot exceed 255 characters.")]
        public string TypeOfExpense { get; set; }

        [Required]
        public int AmountOfExpense { get; set; }
    }
}
