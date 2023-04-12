using Microsoft.AspNetCore.Mvc;
using MummyNation_Team0113.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MummyNation_Team0113.Components
{
    public class FilterViewComponent : ViewComponent
    {
            private IMummyNation_Team0113Repository repo { get; set; }

            public FilterViewComponent(IMummyNation_Team0113Repository temp)
            {
                repo = temp;
            }

            public IViewComponentResult Invoke()
            {
            ViewBag.Selected = RouteData?.Values["data"];
            var data = new Dictionary<string, List<string>>();

            var year = repo.burialmain
                .Select(x => x.Fieldbookexcavationyear)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var gender = repo.burialmain
             .Select(x => x.Sex)
             .Distinct()
             .OrderBy(x => x)
             .ToList();

            var depth = repo.burialmain
                .Select (x => x.Depth)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var ageAtDeath = repo.burialmain
                .Select( x => x.Ageatdeath)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var headDirection = repo.burialmain
                .Select(x => x.Headdirection)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var hairColor = repo.burialmain
                .Select(x => x.Haircolor)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            data["year"] = year;
            data["hairColor"] = hairColor;
            data["headDirection"] = headDirection;
            data["ageAtDeath"] = ageAtDeath;
            data["depth"] = depth;
            data["gender"] = gender;

            return View(data);
            }
        }
    }