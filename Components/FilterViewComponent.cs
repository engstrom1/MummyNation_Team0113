using Microsoft.AspNetCore.Mvc;
using MummyNation_Team0113.Models;
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
            var year = repo.burialmain
                .Select(x => x.Fieldbookexcavationyear)
                .Distinct()
                .OrderBy(x => x);
            return View(year);
            }
        }
    }