using MummyNation_Team0113.Models.ViewModels;
using MummyNation_Team0113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MummyNation_Team0113.Models.ViewModels
{

    public class DisplayDataViewModel
    {
        public IQueryable<Burialmain> burialmain { get; set; }

        // list of BurialPageModel, the new class called burial views 

        public List<BurialPageModel> burialViews { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class BurialPageModel
    {
        public long Id { get; set; }
        public string TextileDescription { get; set; }
        // long id 
        // string textile description 
        // return and set in display data controller after joining 

    }
}