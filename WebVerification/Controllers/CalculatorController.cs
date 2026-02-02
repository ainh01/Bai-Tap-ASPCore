using Microsoft.AspNetCore.Mvc;

namespace WebVerification.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Calculate(double a = 0, double b = 0, char op = '+')
        {
            switch (op)
            {
                case '+':
                    ViewBag.KetQua = a + b;
                    break;
                case '-':
                    ViewBag.KetQua = a - b;
                    break;
                case 'x':
                    ViewBag.KetQua = a * b;
                    break;
                case ':':
                    ViewBag.KetQua = a / b;
                    break;
            }
            return View("Index");
        }
    }
    

    }
