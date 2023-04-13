using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MummyNation_Team0113.Models;
using Microsoft.AspNetCore.Http;

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

        public void AddBurialmain(Burialmain burialmain)
        {
            context.Burialmain.Add(burialmain);
            context.SaveChanges();
        }

        public void UpdateBurialmain(Burialmain burialmain)
        {
            context.Burialmain.Update(burialmain);
            context.SaveChanges();
        }

        public void DeleteBurialmain(long id)
        {
            var burialmain = GetBurialmainById(id);
            if (burialmain != null)
            {
                context.Burialmain.Remove(burialmain);
                context.SaveChanges();
            }
        }

        public Burialmain GetBurialmainById(long id)
        {
            return context.Burialmain.FirstOrDefault(b => b.Id == id);
        }

        public MummyContext GetDbContext()
        {
            return context;
        }

        public IQueryable<Textilefunction> textilefunction => context.Textilefunction;

        public IQueryable<Textile> textile => context.Textile;

        public IQueryable<BurialmainTextile> Burialmaintextile => context.BurialmainTextile;

        
    }
}
