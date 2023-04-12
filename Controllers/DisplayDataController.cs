using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MummyNation_Team0113.Models.ViewModels;
using MummyNation_Team0113.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using LinqKit;
using System.Drawing.Printing;

namespace MummyNation_Team0113.Controllers
{
    public class DisplayDataController : Controller
    {
        private IMummyNation_Team0113Repository repo;

        public DisplayDataController(IMummyNation_Team0113Repository temp)
        {
            repo = temp;
        }
        public IActionResult DisplayData(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new DisplayDataViewModel
            {
                burialmain = repo.burialmain
                    .OrderBy(b => b.Id)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBurials = repo.burialmain.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },
            };

            return View("DisplayData", x);
        }
        public IActionResult MummySummary(long bm)
        {
            ViewData["BmId"] = bm;
            Console.Write(bm);
            return View("MummySummary");
        }

        [HttpPost]
        public IActionResult DisplayData(IFormCollection form, int pageNum = 1)
        {
            int pageSize = 10;
            var query = repo.burialmain.AsQueryable();
            var filters = new List<Expression<Func<Burialmain, bool>>>();
            Expression<Func<Burialmain, bool>> combinedFilters = null;

            foreach (string key in form.Keys)
            {
                string value = form[key];
                if (!string.IsNullOrEmpty(value) && value != "" && value != "Select an option")
                {
                    switch (key)
                    {
                        case "year":
                            filters.Add(b => b.Fieldbookexcavationyear == value);
                            break;
                        case "hairColor":
                            filters.Add(b => b.Haircolor == value);
                            break;
                        case "headDirection":
                            filters.Add(b => b.Headdirection == value);
                            break;
                        case "ageAtDeath":
                            filters.Add(b => b.Ageatdeath == value);
                            break;
                        case "depth":
                            filters.Add(b => b.Depth == value);
                            break;
                        case "gender":
                            filters.Add(b => b.Sex == value);
                            break;
                        default:
                            break;
                    }
                }
            }

            // combine all the filters into a single expression
            if (filters.Count > 0)
            {
                combinedFilters = filters.Aggregate((expr1, expr2) => expr1.And(expr2));
            }

            // apply the combined filters to the query
            if (combinedFilters != null)
            {
                query = query.Where(combinedFilters);
                Console.Write("Query: " + query);
            }

            var x = new DisplayDataViewModel
            {
                burialmain = query
                    .OrderBy(b => b.Id)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBurials = query.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },
            };

            return View("DisplayData", x);
        }

    }
}