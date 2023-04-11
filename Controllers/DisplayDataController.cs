using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MummyNation_Team0113.Models.ViewModels;
using MummyNation_Team0113.Models;
using Microsoft.EntityFrameworkCore;

namespace MummyNation_Team0113.Controllers
{
    public class DisplayDataController : Controller
    {
        private IMummyNation_Team0113Repository repo;

        public DisplayDataController(IMummyNation_Team0113Repository temp)
        {
            repo = temp;
        }        
        public IActionResult DisplayData(string data, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new DisplayDataViewModel
            {
                burialmain = repo.burialmain
                .Where(b => (b.Fieldbookexcavationyear == data || b.Sex == data || data == null))
                //.Where(b => (b.Fieldbookexcavationyear == data || b.Sex == data || data == null) && !(data == "M" && b.Sex != "M"))
                //.OrderBy(b => b.Sex == null)
                //.ThenBy(b => b.Fieldbookexcavationyear == null)
                .OrderBy(b => b.Burialid)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBurials = repo.burialmain.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                    
                }
                
            };

            return View("DisplayData", x);
        }
        public IActionResult MummySummary()
        {
            return View();
        }
    }
}
