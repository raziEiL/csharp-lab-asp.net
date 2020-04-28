using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_calculator.Models;

namespace mvc_calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculator(Calculator calc, string command)
        {
            if (command == null)
                return View();

            calc.operation(command);
            return View(calc);
        }

        public IActionResult HexCalculator(HexCalculator calc, string command)
        {
            if (command == null)
                return View();

            calc.hexOperation(command);
            return View(calc);
        }

        public IActionResult Array(Calculator calc, string command)
        {
            if (command == null)
                return View();

            switch (command)
            {
                case "Сумма нечетных элементов":
                    calc.array(true);
                    break;
                case "Сумма четных элементов":
                    calc.array(false);
                    break;
            }
            return View(calc);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
