using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MummyNation_Team0113.Models.ViewModels;

namespace MummyNation_Team0113.Controllers
{
    public class DisplayDataController : Controller
    {
        public IActionResult DisplayData()
        {
            return View(new DisplayDataViewModel());
        }
    }
}
