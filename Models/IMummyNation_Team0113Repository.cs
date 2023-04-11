using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MummyNation_Team0113.Models
{
    public interface IMummyNation_Team0113Repository
    {
        IQueryable<Burialmain> burialmain { get; }
    }
}