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
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var gender = repo.burialmain
                .Select(x => x.Sex)
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var depth = repo.burialmain
                .Select(x => x.Depth)
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var ageAtDeath = repo.burialmain
                .Select(x => x.Ageatdeath)
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var headDirection = repo.burialmain
                .Select(x => x.Headdirection)
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var hairColor = repo.burialmain
                .Select(x => x.Haircolor)
                .Where(x => !string.IsNullOrEmpty(x))
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var textilefunction = repo.textilefunction
                .Select(x => x.Value)
                .Distinct()
                .OrderBy(x => x)
                .ToList();


            data["Year Of Excavation"] = year;
            data["Hair Color"] = hairColor;
            data["Head Direction"] = headDirection;
            data["Age At Death"] = ageAtDeath;
            data["Depth"] = depth;
            data["Sex"] = gender;
            data["Textile Function"] = textilefunction;

            return View(data);
        }

    }
}