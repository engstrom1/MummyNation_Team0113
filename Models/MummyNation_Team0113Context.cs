using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MummyNation_Team0113.Models
{
    public partial class MummyNation_team0113Context : DbContext
    {
        public MummyNation_team0113Context()
        {

        }

        public MummyNation_team0113Context(DbContextOptions<MummyNation_team0113Context> options) : base(options)
        {

        }

        public virtual DbSet<Burialmain> burialmain { get; set; }

    }
}
