using Microsoft.AspNetCore.Mvc;
using MummyNation_Team0113.Models;
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
                ViewBag.Selected = RouteData?.Values["year"];
            var data = new Dictionary<string, List<string>>();

            var year = repo.burialmain
                .Select(x => x.Fieldbookexcavationyear)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            data["year"] = year;
            return View(data);
            }
        }
    }