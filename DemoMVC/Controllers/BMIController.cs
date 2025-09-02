using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class BMIController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(double weight, double height)
        {
            var bmi = new BmiModel
            {
                Weight = weight,
                Height = height
            };

            if (height > 0)
            {
                bmi.BMI = weight / (height * height);

                if (bmi.BMI < 18.5)
                    bmi.Category = "Gầy";
                else if (bmi.BMI < 25)
                    bmi.Category = "Bình thường";
                else if (bmi.BMI < 30)
                    bmi.Category = "Thừa cân";
                else
                    bmi.Category = "Béo phì";
            }
            else
            {
                bmi.BMI = 0;
                bmi.Category = "Chiều cao không hợp lệ";
            }

            return View("Result", bmi);
        }
    }
}
