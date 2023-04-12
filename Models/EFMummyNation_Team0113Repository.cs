using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MummyNation_Team0113.Models;

namespace MummyNation_Team0113.Models
{
    public class EFMummyNation_Team0113Repository : IMummyNation_Team0113Repository
    {
        private MummyContext context { get; set; }

        public EFMummyNation_Team0113Repository(MummyContext temp)
        {
            context = temp;
        }
        public IQueryable<Burialmain> burialmain => context.Burialmain;

        public IQueryable<Textilefunction> textilefunction => context.Textilefunction;

        public IQueryable<Textile> textile => context.Textile;

        public IQueryable<BurialmainTextile> Burialmaintextile => context.BurialmainTextile;

        
    }
}
