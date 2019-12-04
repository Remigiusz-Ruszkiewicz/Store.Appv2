using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.App.Services;

namespace Store.App.Controllers
{
    public class ProductsCreateController : Controller
    {
        public IActionResult Dodaj()
        {
            return View();
        }
    }
}