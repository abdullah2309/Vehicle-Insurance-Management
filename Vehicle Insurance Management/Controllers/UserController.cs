using Microsoft.AspNetCore.Mvc;
using Vehicle_Insurance_Management.Models;
using Microsoft.AspNetCore.Http;
using Vehicle_Insurance_Management.Models;
using Vehicle_Insurance_Management.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace Vehicle_Insurance_Management.Controllers
{
    public class UserController : Controller
    {
        private readonly mydbcontext dbcontext;
        private readonly IHttpContextAccessor http;
        public IWebHostEnvironment Web { get; }

        public UserController(mydbcontext dbcontext,IWebHostEnvironment web , IHttpContextAccessor http)
        {
            this.dbcontext = dbcontext;
            Web = web;
            this.http = http;
        }
        public IActionResult Index()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        public IActionResult CustomerInformation()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }
            var dataExists = dbcontext.Customer_Information.Any(a => a.Login_Id == userId.Value);
            if (dataExists)
            {
                return RedirectToAction("C_I_Show"); 
            }

            return View(); 
        }

        [HttpPost]
        public IActionResult CustomerInformation(Customer_Information customer)
        {
            var userId = http.HttpContext.Session.GetInt32("User_Id"); 

            if (userId.HasValue) 
            {
                customer.Login_Id = userId.Value; 

                if (ModelState.IsValid)
                {
                    dbcontext.Customer_Information.Add(customer);
                    dbcontext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(customer);
        }
        public IActionResult C_I_Show()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }


            var customerData = dbcontext.Customer_Information.FirstOrDefault(c => c.Login_Id == userId.Value);

            if (customerData == null)
            {
                return View();
            }
            return View(customerData);
        }
        public IActionResult C_I_Edit(int id)
        {
            var data = dbcontext.Customer_Information.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult C_I_Edit(Customer_Information customer)
        {
            var loginId = http.HttpContext.Session.GetInt32("User_Id");

            var existingCustomer = dbcontext.Customer_Information.FirstOrDefault(a => a.Login_Id == loginId);

                if (existingCustomer != null)
                {
                    existingCustomer.Name = customer.Name;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.PhoneNumber = customer.PhoneNumber;
                    existingCustomer.CNIC = customer.CNIC;
                    existingCustomer.DateOfIssue = customer.DateOfIssue;
                    existingCustomer.DateOfExpiry = customer.DateOfExpiry;
                    existingCustomer.DateOfBirth = customer.DateOfBirth;
                    existingCustomer.Sex = customer.Sex;
                    dbcontext.SaveChanges(); 
                    return RedirectToAction("C_I_Show");        
            }
            return View(customer); 
        }

        
        public IActionResult VehicleInformation()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }
            var dataExists = dbcontext.vehicle_Information.Any(v => v.Login_Id == userId.Value);

            if (dataExists)
            {
                return RedirectToAction("V_I_Show");
            }

            return View();
        }

        [HttpPost]
        public IActionResult VehicleInformation(Vehicle_Information vehicle)
        {
            var userId = http.HttpContext.Session.GetInt32("User_Id");

            if (userId.HasValue)
            {
                vehicle.Login_Id = userId.Value;

                if (ModelState.IsValid)
                {
                    dbcontext.vehicle_Information.Add(vehicle);
                    dbcontext.SaveChanges();
                    return RedirectToAction("V_I_Show");
                }
            }
            return View(vehicle);
        }

 
        public IActionResult V_I_Show()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }
            var vehicleData = dbcontext.vehicle_Information.FirstOrDefault(v => v.Login_Id == userId.Value);

            if (vehicleData == null)
            {
                return View();
            }
            return View(vehicleData);
        }

      
        public IActionResult V_I_Edit(int id)
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }
            var data = dbcontext.vehicle_Information.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult V_I_Edit(Vehicle_Information vehicle)
        {
            var loginId = http.HttpContext.Session.GetInt32("User_Id");
            var existingVehicle = dbcontext.vehicle_Information.FirstOrDefault(v => v.Login_Id == loginId);

            if (existingVehicle != null)
            {
                existingVehicle.VehicleName = vehicle.VehicleName;
                existingVehicle.OwnerName = vehicle.OwnerName;
                existingVehicle.Model = vehicle.Model;
                existingVehicle.Version = vehicle.Version;
                existingVehicle.Rate = vehicle.Rate;
                existingVehicle.BodyNumber = vehicle.BodyNumber;
                existingVehicle.EngineNumber = vehicle.EngineNumber;
                existingVehicle.VehicleNumber = vehicle.VehicleNumber;

                dbcontext.SaveChanges();
                return RedirectToAction("V_I_Show");
            }
            return View(vehicle);
        }
   
        public async Task<IActionResult> InsuranceProcess()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

            var dataExists = await dbcontext.insurance_processes.FirstOrDefaultAsync(v => v.Login_Id == userId.Value);

            if (dataExists != null)
            {
                return RedirectToAction("InsuranceDetails");
            }

            var customer = await dbcontext.Customer_Information.FirstOrDefaultAsync(c => c.Login_Id == userId);
            var vehicle = await dbcontext.vehicle_Information.FirstOrDefaultAsync(v => v.Login_Id == userId);

            if (customer == null || vehicle == null)
            {
                TempData["CIVIError"] = "Enter Your Customer Information and Enter Your Vehicle Information.";
                return RedirectToAction("Index");
            }

            return View(new Vehicle_Insurance_Management.Models.insurance_process
            {
                CustomerId = customer.Id,
                VehicleId = vehicle.VehicleId
            });
        }



        [HttpPost]
        public IActionResult InsuranceProcess(Vehicle_Insurance_Management.Models.insurance_process insurance)
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");



            insurance.Login_Id = userId.Value;


            dbcontext.insurance_processes.Add(insurance);
            dbcontext.SaveChanges();
            return RedirectToAction("BillingInformation");


        }

        public async Task<IActionResult> InsuranceDetails()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

            var insuranceData = await dbcontext.insurance_processes
                .Include(i => i.Customer)
                .Include(i => i.Vehicle)
                .FirstOrDefaultAsync(i => i.Login_Id == userId);

            if (insuranceData == null)
            {
                return View();
            }
            return View(insuranceData);
        }

        public async Task<IActionResult> BillingInformation()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

     
            var dataExists = await dbcontext.BillingInformation.FirstOrDefaultAsync(b => b.CustomerId == userId.Value);
            if (dataExists != null)
            {

                return RedirectToAction("BillingDetails");
            }

            var customer = await dbcontext.Customer_Information.FirstOrDefaultAsync(c => c.Login_Id == userId.Value);
            var vehicle = await dbcontext.vehicle_Information.FirstOrDefaultAsync(v => v.Login_Id == userId.Value);


            if (customer == null || vehicle == null)
            {
                TempData["CIVIError"] = "Please enter your Customer and Vehicle Information before proceeding.";
                return RedirectToAction("Index");
            }

            
            return View(new Vehicle_Insurance_Management.Models.BillingInformation
            {
                CustomerId = customer.Id,
                VehicleId = vehicle.VehicleId
            });
        }


        [HttpPost]
        public IActionResult BillingInformation(Vehicle_Insurance_Management.Models.BillingInformation billing)
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                TempData["SessionError"] = "Session expired. Please log in again.";
                return RedirectToAction("Login", "Home");
            }

        

            dbcontext.BillingInformation.Add(billing);
            dbcontext.SaveChanges();

            TempData["SuccessMessage"] = "Billing information saved successfully.";
            return RedirectToAction("BillingDetails");
        }
        public async Task<IActionResult> BillingDetails()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

            if (!userId.HasValue)
            {
               TempData["SessionError"] = "Session expired. Please log in again.";
               return RedirectToAction("Login", "Home");
            }

         var billingData = await dbcontext.BillingInformation
        .Include(b => b.Customer) 
        .Include(b => b.Vehicle)   
        .FirstOrDefaultAsync(b => b.CustomerId == userId.Value);

            if (billingData == null)
            {
                TempData["InfoMessage"] = "No billing information found.";
                return View();  
            }

    
          return View(billingData);
       }
        public IActionResult ClaimDetails()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }

            if (userId == null)
            {
                TempData["Error"] = "User not found. Please log in.";
                return RedirectToAction("Login", "User");
            }
            var hasBillingInfo = dbcontext.BillingInformation.Any(b => b.CustomerId == userId);

            if (!hasBillingInfo)
            {
                TempData["Error"] = "Please enter your billing information before filing a claim.";
                return RedirectToAction("BillingInformation", "User");
            }
            ViewBag.PolicyName = new SelectList(dbcontext.insurancepolicies, "Id", "PolicyName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ClaimDetails(Vehicle_Insurance_Management.Models.ClaimDetails claim)
        {
            dbcontext.claimDetails.Add(claim);
            await dbcontext.SaveChangesAsync();
            TempData["Success"] = "Claim added successfully!";
            return RedirectToAction("Index");
        }
        public IActionResult Feedback()
        {
            var userId = http.HttpContext?.Session.GetInt32("User_Id");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Feedback(Feedback feedback)
        {
            
                feedback.SubmittedAt = DateTime.Now;
                dbcontext.feedbacks.Add(feedback);
                dbcontext.SaveChanges();

                TempData["Feedback"] = "Thank you for your feedback!";
                return RedirectToAction("Feedback"); 
         
        }



    }
}
