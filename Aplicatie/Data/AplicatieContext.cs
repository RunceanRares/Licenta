using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aplicatie.Model;

namespace Aplicatie.Models
{
    public class AplicatieContext : DbContext
    {
        public AplicatieContext (DbContextOptions<AplicatieContext> options)
            : base(options)
        {
        }

        public DbSet<Aplicatie.Model.Incercare> Incercare { get; set; }
    }
}
