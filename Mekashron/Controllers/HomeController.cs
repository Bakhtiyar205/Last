using Mekashron.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mekashron.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            LoginVM loginVM = new LoginVM();
            return View(loginVM);
        }

        

        public IActionResult Login()
        {
            LoginVM loginVM = new LoginVM();
            return View(loginVM);
        }

        //public IActionResult Login(MekashronLogin.LoginRequest request)

        //{
        //    LoginVM loginVM = new LoginVM()
        //    {
        //        Name = request.UserName,
        //        Password = request.Password,
        //        LoginResult = "success"

        //    };
        //    return View(loginVM);
        //}

        [HttpPost]
        public IActionResult Login(string name, string password)
        {
            MekashronLogin.ICUTechClient request = new MekashronLogin.ICUTechClient();
            Task<MekashronLogin.LoginResponse> result = request.LoginAsync(name, password, "3151");


            MekashronLogin.LoginResponse loginResponse = result.Result;
            LoginVM loginVM = new LoginVM()
            {
                Result = result.Result.@return,
            };
            return View(loginVM);
        }
    }
}
