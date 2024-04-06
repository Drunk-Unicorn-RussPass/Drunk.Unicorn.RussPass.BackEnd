using Drunk.Unicorn.RussPass.Users.Data.Attributes;
using Drunk.Unicorn.RussPass.Users.Data.Entity;
using Drunk.Unicorn.RussPass.Users.General.Expansions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.EF
{
    public partial class ServiceDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
