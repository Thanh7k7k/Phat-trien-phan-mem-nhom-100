using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ketqua(double number1, double number2, string operation)
        {
            var model = new Calculator
            {
                Number1 = number1,
                Number2 = number2,
                Operation = operation
            };

            switch (operation)
            {
                case "+":
                    model.Result = number1 + number2;
                    break;
                case "-":
                    model.Result = number1 - number2;
                    break;
                case "*":
                    model.Result = number1 * number2;
                    break;
                case "/":
                    model.Result = number2 != 0 ? number1 / number2 : 0;
                    break;
                default:
                    model.Result = 0;
                    break;
            }

            return View(model);
        }
    }
}
