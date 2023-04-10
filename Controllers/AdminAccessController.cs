using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MummyNation_Team0113.Controllers
{
    public class AdminAccessController : Controller
    {
        public IActionResult AddRecordAdmin()
        {
            return View();
        }

        public IActionResult EditDeleteAdmin()
        {
            return View();
        }
    }
}
