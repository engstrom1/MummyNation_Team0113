using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MummyNation_Team0113.Models.ViewModels;
using MummyNation_Team0113.Models;

namespace MummyNation_Team0113.Controllers
{
    public class DisplayDataController : Controller
    {
        private IMummyNation_Team0113Repository repo;

        public DisplayDataController(IMummyNation_Team0113Repository temp)
        {
            repo = temp;
        }
        public IActionResult DisplayData(string year)
        {
            var x = new DisplayDataViewModel
            {
                burialmain = repo.burialmain
                .Where(x => x.Fieldbookexcavationyear == year || year == null)
                .OrderBy(x => x.Id)
            };

            return View("DisplayData", x);
        }
    }
}
