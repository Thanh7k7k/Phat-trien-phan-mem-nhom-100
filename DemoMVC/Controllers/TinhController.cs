using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class TinhController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(double number1, double number2, string operation)
        {
            var calc = new Calculator
            {
                Number1 = number1,
                Number2 = number2,
                Operation = operation
            };

            switch (operation)
            {
                case "add":
                    calc.Result = number1 + number2;
                    break;
                case "sub":
                    calc.Result = number1 - number2;
                    break;
                case "mul":
                    calc.Result = number1 * number2;
                    break;
                case "div":
                    calc.Result = number2 != 0 ? number1 / number2 : double.NaN;
                    break;
            }

            return View("Result", calc);
        }
    }
}
