using System;
using System.ComponentModel.DataAnnotations;

namespace Vehicle_Insurance_Management.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public int UserId { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; } 
        public DateTime SubmittedAt { get; set; } = DateTime.Now;

      

    }
}

