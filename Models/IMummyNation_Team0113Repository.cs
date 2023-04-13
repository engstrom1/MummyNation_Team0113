using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MummyNation_Team0113.Models
{
    public interface IMummyNation_Team0113Repository
    {
        IQueryable<Burialmain> burialmain { get; }

        void AddBurialmain(Burialmain burialmain);
        void UpdateBurialmain(Burialmain burialmain);
        void DeleteBurialmain(long id);
        Burialmain GetBurialmainById(long id);
        MummyContext GetDbContext();
    }
}