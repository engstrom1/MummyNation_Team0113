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
        public string Squarenorthsouth { get; set; }
        public string Headdirection { get; set; }
        public string Sex { get; set; }
        public string Northsouth { get; set; }
        public string Depth { get; set; }
        public string Eastwest { get; set; }
        public string Adultsubadult { get; set; }
        public string Facebundles { get; set; }
        public string Southtohead { get; set; }
        public string Preservation { get; set; }
        public string Fieldbookpage { get; set; }
        public string Squareeastwest { get; set; }
        public string Goods { get; set; }
        public string Text { get; set; }
        public string Wrapping { get; set; }
        public string Haircolor { get; set; }
        public string Westtohead { get; set; }
        public string Samplescollected { get; set; }
        public string Area { get; set; }
        public long? Burialid { get; set; }
        public string Length { get; set; }
        public string Burialnumber { get; set; }
        public string Dataexpertinitials { get; set; }
        public string Westtofeet { get; set; }
        public string Ageatdeath { get; set; }
        public string Southtofeet { get; set; }
        public string Excavationrecorder { get; set; }
        public string Photos { get; set; }
        public string Hair { get; set; }
        public string Burialmaterials { get; set; }
        public DateTime? Dateofexcavation { get; set; }
        public string Fieldbookexcavationyear { get; set; }
        public string Clusternumber { get; set; }
        public string Shaftnumber { get; set; }
        public long TextileId { get; set; }
        public string Locale { get; set; }
        public int? Textileid { get; set; }
        public string Description { get; set; }
        public string TextileBurialnumber { get; set; }
        public string Estimatedperiod { get; set; }
        public DateTime? Sampledate { get; set; }
        public DateTime? Photographeddate { get; set; }
        public string Direction { get; set; }

    }
}