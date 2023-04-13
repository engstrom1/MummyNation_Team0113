using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MummyNation_Team0113.Models.ViewModels;
using MummyNation_Team0113.Models;

namespace MummyNation_Team0113.Controllers
{
    public class CrudController : Controller
    {
        private IMummyNation_Team0113Repository repo;

        public CrudController(IMummyNation_Team0113Repository temp)
        {
            repo = temp;
        }
        
        public IActionResult Create(Burialmain burialmain)
        {     
            //repo.AddBurialmain(burialmain);
            return View(burialmain);
        }

        [HttpPost]
        public IActionResult CreateConfirmed(Burialmain burialmain)
        {
            var context = repo.GetDbContext();
            var maxId = context.Burialmain.Max(b => b.Id);
            burialmain.Id = maxId + 1;
            repo.AddBurialmain(burialmain);
            return View();
        }

        public IActionResult Remove(long id)
        {
            ViewData["BmId"] = id;
            repo.DeleteBurialmain(id);
            return View();
        }

        public IActionResult Edit(long id)
        {
            ViewData["BmId"] = id;
            ViewData["dbContext"] = repo.GetDbContext();
            return View();
        }
        public IActionResult EditConfirmed(Burialmain burialmain, long id)
        {
            burialmain.Id = id;
            repo.UpdateBurialmain(burialmain);
            return View();
        }
    }
}
