using EcommerceShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehicle_Insurance_Management.Models;

namespace Vehicle_Insurance_Management.Controllers
{
    public class AdminController : Controller
    {
        public mydbcontext Dbcontext { get; }
        public IWebHostEnvironment Web { get; }
        public IHttpContextAccessor Http { get; }

        public AdminController(mydbcontext dbcontext , IWebHostEnvironment web , IHttpContextAccessor  http)
        {
            Dbcontext = dbcontext;
            Web = web;
            Http = http;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                return View();
            }
            return RedirectToAction("Login");
           
        }
        public IActionResult sigin()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = Dbcontext.signUp.ToList();
               return View(data);
            }
            return RedirectToAction("Login");
        }
        public IActionResult signUpDelete(int id)
        {
            var data = Dbcontext.signUp.Find(id);
            return View(data);
        }
        public IActionResult CsignUpDelete(int id)
        {
            var data = Dbcontext.signUp.Find(id);
            Dbcontext.signUp.Remove(data);
            Dbcontext.SaveChanges();
            return RedirectToAction("sigin");
        }
        public IActionResult AddPolicyType()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                ViewData["ShowPolicyType"] = Dbcontext.addpolicytypes;
                return View();
            }
            return RedirectToAction("Login");

        }
        [HttpPost]
        public IActionResult AddPolicyType(Addpolicytype add)
        {
         
            Dbcontext.addpolicytypes.Add(add);
            Dbcontext.SaveChanges();
            return RedirectToAction("AddPolicyType");


        }
        public IActionResult _ShowPolicyType()
        {
            var data = Dbcontext.addpolicytypes.ToList();
            return View(data);
        }
        public IActionResult PolicyEdit(int id)
        {
            var data = Dbcontext.addpolicytypes.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult PolicyEdit(int id , Addpolicytype add)
        {
            var data = Dbcontext.addpolicytypes.Find(id);
            data.policy_name = add.policy_name;
            Dbcontext.SaveChanges();
            return RedirectToAction("AddPolicyType");
        }
        public IActionResult PolicyDetete(int id)
        {
            var data = Dbcontext.addpolicytypes.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult CPolicyDetete(int id)
        {
            var data = Dbcontext.addpolicytypes.Find(id);
            Dbcontext.addpolicytypes.Remove(data);
            Dbcontext.SaveChanges();
            return RedirectToAction("AddPolicyType");
        }
        public IActionResult AddInsuracePolicy()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
               
            ViewData["ShowInsuracePolicy"] = Dbcontext.insurancepolicies;
            ViewBag.PolicyType = new SelectList(Dbcontext.addpolicytypes, "id", "policy_name");
            return View();
            }
            return RedirectToAction("Login");

        }
        [HttpPost] 
        public IActionResult AddInsuracePolicy(insurancepolicy policy , IFormFile PolicyImages)
        { 
            var location = Path.Combine(Web.WebRootPath, "policyimages", PolicyImages.FileName);
            FileStream file = new FileStream(location, FileMode.Create);
            PolicyImages.CopyTo(file);
            policy.PolicyImages = PolicyImages.FileName;
            Dbcontext.insurancepolicies.Add(policy);
            Dbcontext.SaveChanges();
            return RedirectToAction("AddInsuracePolicy");

        }
        public IActionResult _ShowInsuracePolicy()
        {
            var data = Dbcontext.insurancepolicies.Include(x => x.Addpolicytype).ToList();
            return View(data);
        }
        public IActionResult DeleteInsuracePolicy(int id)
        {
            var data = Dbcontext.insurancepolicies.Find(id);
            return View(data);
        }
        public IActionResult CDeleteInsuracePolicy(int id)
        {
            var data = Dbcontext.insurancepolicies.Find(id);
            var old_img = Path.Combine(Web.WebRootPath, "policyimages", data.PolicyImages);
            if (System.IO.File.Exists(old_img))
            {
                System.IO.File.Delete(old_img);
            }
            Dbcontext.insurancepolicies.Remove(data);
            Dbcontext.SaveChanges();
            return RedirectToAction("AddInsuracePolicy");
        }
        public IActionResult EditInsuracePolicy(int id)
        {
            ViewBag.editPolicyType = new SelectList(Dbcontext.addpolicytypes, "id", "policy_name");
            var data = Dbcontext.insurancepolicies.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditInsuracePolicy(insurancepolicy policy , IFormFile PolicyImages)
        {
            var data = Dbcontext.insurancepolicies.Where(a => a.Id == policy.Id).FirstOrDefault();
            if (PolicyImages != null && PolicyImages.Length > 0)
            {
                var old_img = Path.Combine(Web.WebRootPath, "policyimages", data.PolicyImages);
                if (System.IO.File.Exists(old_img))
                {
                    System.IO.File.Delete(old_img);
                }
                var location = Path.Combine(Web.WebRootPath, "policyimages", PolicyImages.FileName);
                FileStream file = new FileStream(location, FileMode.Create);
                PolicyImages.CopyTo(file);
                data.PolicyImages = PolicyImages.FileName;
            }
            else
            {
                policy.PolicyImages = data.PolicyImages;
            }
            data.PolicyName = policy.PolicyName;
            data.PolicyType = policy.PolicyType;
            data.PolicyDescription = policy.PolicyDescription;
            Dbcontext.SaveChanges();
            return RedirectToAction("AddInsuracePolicy");
        }
        public IActionResult Customer_Details()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = Dbcontext.Customer_Information.ToList();
                return View(data);
            }
            return RedirectToAction("Login");
          
        }
        public IActionResult DeleteCustomer(int id)
        {
            var data = Dbcontext.Customer_Information.Find(id);
            return View(data);
        }
        public IActionResult CDeleteCustomer(int id)
        {
            var data = Dbcontext.Customer_Information.Find(id);
            Dbcontext.Customer_Information.Remove(data);
            Dbcontext.SaveChanges();
            return RedirectToAction("Customer_Details");
        }
        public IActionResult Vehicle_Details()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = Dbcontext.vehicle_Information.ToList();
                return View(data);
            }
            return RedirectToAction("Login");
           
        }
        public IActionResult DeleteVehicle(int id)
        {
            var data = Dbcontext.vehicle_Information.Find(id);
            return View(data);
        }
        public IActionResult CDeleteVehicle(int id)
        {
            var data = Dbcontext.vehicle_Information.Find(id);
            Dbcontext.vehicle_Information.Remove(data);
            Dbcontext.SaveChanges();
            return RedirectToAction("Vehicle_Details");
        }

        public IActionResult Insurance_Process()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var insuranceData = Dbcontext.insurance_processes
                .Include(i => i.Customer) 
                .Include(i => i.Vehicle)  
                .ToList();

                return View(insuranceData);
            }
            return RedirectToAction("Login");
 
        }
       public IActionResult DeleteInsurance(int id)
       {
            var data = Dbcontext.insurance_processes.Find(id);
            return View(data);
       }
        public IActionResult CDeleteInsurance(int id)
        {
            var data = Dbcontext.insurance_processes.Find(id);
            Dbcontext.insurance_processes.Remove(data);
            Dbcontext.SaveChanges();
            return RedirectToAction("Insurance_Process");
        }
        public IActionResult BillingDetails()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = Dbcontext.BillingInformation
                .Include(b => b.Customer)
                .Include(b => b.Vehicle)
                .ToList();
                return View(data);
            }
            return RedirectToAction("Login");
           
        }
        public IActionResult DeleteBilling(int id)
        {
            var data = Dbcontext.BillingInformation.Find(id);
            return View(data);
        }
        public IActionResult CDeleteBilling(int id)
        {
            var data = Dbcontext.BillingInformation.Find(id);
            Dbcontext.BillingInformation.Remove(data);
            Dbcontext.SaveChanges();
            return RedirectToAction("BillingDetails");
        }
        public IActionResult ClaimDetails()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var claims = Dbcontext.claimDetails
               .Include(c => c.Insurancepolicy)
               .ToList();

                return View(claims);
            }
            return RedirectToAction("Login");
          
        }
        public IActionResult DeleteClaim(int id)
        {
            var data = Dbcontext.claimDetails.Find(id);
            return View(data);
        }
        public IActionResult CDeleteClaim(int id)
        {
            var data = Dbcontext.claimDetails.Find(id);
            Dbcontext.claimDetails.Remove(data);
            Dbcontext.SaveChanges();
            return RedirectToAction("ClaimDetails");
        }
        public IActionResult AddExpense()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                ViewData["ShowExpenses"] = Dbcontext.CompanyExpenses.ToList();
                return View();
            }
            return RedirectToAction("Login");

           
        }
        public IActionResult _ShowExpenses()
        {
            var data = Dbcontext.CompanyExpenses.ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult AddExpense(CompanyExpenses expense)
        {
            if (ModelState.IsValid)
            {
                Dbcontext.CompanyExpenses.Add(expense);
                Dbcontext.SaveChanges();
                return RedirectToAction("AddExpense");
            }
            return View(expense);
        }
        public IActionResult DeleteExpense(int id)
        {
            var data = Dbcontext.CompanyExpenses.Find(id);
            Dbcontext.CompanyExpenses.Remove(data);
            Dbcontext.SaveChanges();
            return RedirectToAction("AddExpense");

        }
       

        public IActionResult AddEstimate()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                
        
            ViewData["showEstimates"] = Dbcontext.estimates;
            ViewBag.CustomerList = Dbcontext.Customer_Information.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),   // Foreign Key (CustomerId)
                Text = c.Name + " - " + c.PhoneNumber // Display Name and Phone
            }).ToList();

            return View();
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult AddEstimate(Estimate estimate)
        {
            if (estimate.CustomerId == 0) // Ensure Customer ID is selected
            {
                ModelState.AddModelError("CustomerId", "Please select a valid customer.");
                ViewBag.CustomerList = Dbcontext.Customer_Information.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name + " - " + c.PhoneNumber
                }).ToList();
                return View(estimate);
            }

            Dbcontext.estimates.Add(estimate);
            Dbcontext.SaveChanges();

            return RedirectToAction("AddEstimate");

        }
 
        public IActionResult _showEstimates()
        {
            var estimates = Dbcontext.estimates
                .Include(e => e.Customer) // Ensure this navigation property exists
                .ToList();

            return View(estimates);
        }
        [HttpPost]
        public IActionResult DeleteEstimate(int id)
        {
            var data = Dbcontext.estimates.Find(id);
            Dbcontext.estimates.Remove(data);
            Dbcontext.SaveChanges();

            return RedirectToAction("AddEstimate");
        }

        public IActionResult FeedBack()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = Dbcontext.feedbacks.ToList();
                return View(data);
            }
            return RedirectToAction("Login");
           
        }





        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(adminlogin login)
        {
            var data = Dbcontext.adminlogins.Where(a => a.Email == login.Email && a.password == login.password).FirstOrDefault();
            if (data != null)
            {
                HttpContext.Session.SetString("adminlogin", data.Email);
                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                HttpContext.Session.Remove("adminlogin");
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");
        }

        public IActionResult show()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = Dbcontext.adminlogins.ToList();
                return View(data);
            }
           
            return RedirectToAction("Login");


        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = Dbcontext.adminlogins.Find(id);
                return View(data);
            }
            return RedirectToAction("Index", "admin");



        }
        [HttpPost]
        public IActionResult Edit(int id, adminlogin login)
        {
            var data = Dbcontext.adminlogins.Find(id);
            data.Email = login.Email;
            data.password = login.password;
            Dbcontext.SaveChanges();
            return RedirectToAction("Index", "admin");

        }




    }
}
