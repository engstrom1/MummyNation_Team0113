using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MummyNation_Team0113.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<IdentityUserRole<string>> Roles { get; set; }
    }
}
