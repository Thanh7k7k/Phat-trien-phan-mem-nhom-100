namespace DemoMVC.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using DemoMVC.Models;

    public class personController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(person ps)
        {
            string strOutput = "xin chao" + ps.personId + "-" + ps.fullname + "-" + ps.address +"-"+ps.YearOfBirth+"-"+ps.Age;
            ViewBag.infoperson = strOutput;
            return View();
        }
    }
}