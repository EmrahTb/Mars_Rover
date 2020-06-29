using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Models;
using BusinessLayer.Operation;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculate _calculate;
        public HomeController(ICalculate calculate)
        {
            _calculate = calculate;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Calculete(CalculeteRequest calculeteRequest)
        {
            ICalculate calculate = _calculate;
            List<CalculateResponse> result = calculate.Moving(calculeteRequest);
            return new JsonResult(result);
        }
    }
}
