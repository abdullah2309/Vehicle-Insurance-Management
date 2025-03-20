using EcommerceShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Vehicle_Insurance_Management.Models
{
    public class mydbcontext: DbContext
    {
        public mydbcontext(DbContextOptions<mydbcontext> options) : base(options)
        {
        }
        public DbSet<Addpolicytype> addpolicytypes { get; set; }
        public DbSet<insurancepolicy> insurancepolicies { get; set; }
        public DbSet<SignUp> signUp  { get; set; }
        public DbSet<Customer_Information>  Customer_Information  { get; set; }
        public DbSet<Vehicle_Information> vehicle_Information { get; set; }
        public DbSet<insurance_process> insurance_processes  { get; set; }
        public DbSet<BillingInformation> BillingInformation   { get; set; }
        public DbSet<ClaimDetails> claimDetails { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }
        public DbSet<CompanyExpenses> CompanyExpenses  { get; set; }
        public DbSet<Estimate> estimates  { get; set; }
        public DbSet<adminlogin> adminlogins   { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships if needed
            modelBuilder.Entity<insurance_process>()
                .HasOne(i => i.Customer)
                .WithMany()
                .HasForeignKey(i => i.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<insurance_process>()
                .HasOne(i => i.Vehicle)
                .WithMany()
                .HasForeignKey(i => i.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

