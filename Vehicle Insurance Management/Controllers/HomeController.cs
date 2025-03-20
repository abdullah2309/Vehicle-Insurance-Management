using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Vehicle_Insurance_Management.Models;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;

namespace Vehicle_Insurance_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public mydbcontext Dbcontext { get; }

        public HomeController(mydbcontext dbcontext , IConfiguration  configuration)
        {
            Dbcontext = dbcontext;
            this._configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Policy()
        {
            ViewData["_ShowPolicycart"] = Dbcontext.insurancepolicies;
            return View();
        }
        public IActionResult _ShowPolicycart()
        {
            var data = Dbcontext.insurancepolicies.Include(x => x.Addpolicytype).ToList();
            return View(data);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(SignUp signUp)
        {
            var user = Dbcontext.signUp.FirstOrDefault(x => x.User_Email == signUp.User_Email && x.User_Password == signUp.User_Password);
            if (user != null)
            {
                HttpContext.Session.SetString("User_Email", user.User_Name);
                HttpContext.Session.SetInt32("User_Id", user.Id);
                return RedirectToAction("Index", "User");
            }
            TempData["login"] = "InCorrect Email and Password"; 

            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                var existingUser = Dbcontext.signUp.FirstOrDefault(u => u.User_Email == signUp.User_Email);
                if (existingUser != null)
                {
                    TempData["already"] = "This email is already registered!";
                    return View(signUp);
                }

                // Save new user
                Dbcontext.Add(signUp);
                Dbcontext.SaveChanges();

        //        // Send Welcome Email
        //        var emailService = new EmailService(_configuration);
        //        string subject = "Welcome to Vehicle Insurance Management!";
        //        string body = $@"
        //<div style='font-family: Arial, sans-serif; color: #333;'>
        //<h2 style='color: #007bff;'>Welcome, {signUp.User_Name}!</h2>
        //<p>Thank you for signing up with <strong>Vehicle Insurance Management</strong>.</p>
        //<p>You can now access your dashboard and manage your insurance policies.</p>
        //<p><strong>Email:</strong> {signUp.User_Email}</p>
        //<p><strong>Password:</strong> (Hidden for security)</p>
        //<p>Best regards,</p>
        //<p><strong>Vehicle Insurance Management Team</strong></p>
        //</div>";


        //        emailService.SendEmail(signUp.User_Email, subject, body);

                TempData["SuccessMessage"] = "Registration successful!";
                return RedirectToAction("Login");
            }

            TempData["ErrorMessage"] = "Please fix the errors in the form.";
            return View(signUp);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
