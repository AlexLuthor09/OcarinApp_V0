using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcarinAPI.Models;

namespace OcarinAPI.Data
{
    public class OcarinAPIContext : DbContext
    {
        public OcarinAPIContext(DbContextOptions<OcarinAPIContext> options)
            : base(options)
        {
        }
        public DbSet<OcarinAPI.Models.Animateurs> Animateurs { get; set; } = default!;

        public DbSet<OcarinAPI.Models.Enfants> Enfants { get; set; } = default!;

        public DbSet<OcarinAPI.Models.Inscription> Inscription { get; set; } = default!;

        public DbSet<OcarinAPI.Models.Plaines> Plaines { get; set; } = default!;

        public DbSet<OcarinAPI.Models.Responsables_Taches> Responsables_Taches { get; set; } = default!;

        public DbSet<OcarinAPI.Models.Taches> Taches { get; set; } = default!;

    
    }
}
