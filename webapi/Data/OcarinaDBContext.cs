using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OcarinAPI.Models;

namespace OcarinAPI.Data
{
    public class OcarinaDBContext : DbContext
    {
        public OcarinaDBContext(DbContextOptions<OcarinaDBContext> options) : base(options) { }
        public DbSet<Animateurs> Animateurs { get; set; }
        public DbSet<Animateurs_Plaines> Animateurs_Plaines { get; set; }
        public DbSet<Enfants> Enfants { get; set; }
        public DbSet<Enfants_Plaines> Enfants_Plaines { get; set; }
        public DbSet<Plaines> Plaines { get; set; }
        public DbSet<Taches> Taches { get; set; }
        public DbSet<Taches_Plaines> Taches_Plaines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Définir la clé primaire pour l'entité Animateurs
            modelBuilder.Entity<Animateurs>().HasKey(a => a.ID_animateur);
     
            modelBuilder.Entity<Animateurs_Plaines>().HasKey(at => new { at.ID_animateur, at.ID_plaine });
         
            modelBuilder.Entity<Enfants>().HasKey(a => a.ID_enfant);
            modelBuilder.Entity<Enfants>().ToTable(tb => tb.HasTrigger("Trg_Enfants_Age"));

            modelBuilder.Entity<Enfants_Plaines>().HasKey(a => new { a.ID_enfant, a.ID_plaine });
            modelBuilder.Entity<Enfants_Plaines>().ToTable(tb => tb.HasTrigger("Trg_Enfants_Plaines_DateInscription"));
            

            modelBuilder.Entity<Plaines>().HasKey(a => a.ID_plaine);
            
            modelBuilder.Entity<Taches>().HasKey(a => a.ID_tache);
            
            modelBuilder.Entity<Taches_Plaines>().HasKey(a => new {a.ID_tache, a.ID_plaine });
            // Vous pouvez également ajouter d'autres configurations ici si nécessaire.

            base.OnModelCreating(modelBuilder);
        }
    }
}

    
