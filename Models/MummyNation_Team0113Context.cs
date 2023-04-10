using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MummyNation_Team0113.Models
{
    public partial class MummyNation_Team0113Context : DbContext
    {
        public MummyNation_Team0113Context()
        {

        }

        public MummyNation_Team0113Context(DbContextOptions<MummyNation_Team0113Context> options) : base(options)
        {

        }

        public DbSet<Burialmain> Burials { get; set; }

    }
}
