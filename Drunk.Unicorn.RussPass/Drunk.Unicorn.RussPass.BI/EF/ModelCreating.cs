using Drunk.Unicorn.RussPass.Data.Attributes;
using Drunk.Unicorn.RussPass.Data.Entity;
using Drunk.Unicorn.RussPass.General.Expansions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.EF
{
    public partial class ServiceDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
