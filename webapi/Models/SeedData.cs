using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OcarinAPI.Data;
using System;
using System.Linq;

namespace OcarinAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OcarinaDBContext(serviceProvider.GetRequiredService<DbContextOptions<OcarinaDBContext>>()))
            {
                // Look for any Enfants.
                if (!context.Enfants.Any())
                {
                    // DB has been seeded so no movies are added if there are one or more movies in the DB 
                    context.Enfants.AddRange(
                        new Enfants
                        {
                            Nom = "PetitEnfant",
                            Prenom = "Marius",
                            DateNaissance = DateTime.Parse("2020-02-25"),
                            TrancheAge = "3-6 ans",
                            Adresse = "Avenue des tes mort, 69 évreux",
                            NumeroTelephone = "0253694587",
                            Email = "gpax@outlook.com",
                            FicheSante = false,
                            StatutMC = "Membre-BIM",
                            Allergie = "RAS",
                            Commentaire = "C'est un petit con"
                        },
                        new Enfants
                        {
                            Nom ="MoyenEnfant",
                            Prenom = "Jul",
                            DateNaissance = DateTime.Parse("2016-06-18"),
                            TrancheAge = "6-9 ans",
                            Adresse = "Avenue des tes mort, 69 évreux",
                            NumeroTelephone = "0253694587",
                            Email = "gpax@outlook.com",
                            FicheSante = false,
                            StatutMC = "Non-membre",
                            Allergie = "RAS",
                            Commentaire = "C'est un petit con"

                        },
                        new Enfants
                        {
                            Nom = "GrandEnfant",
                            Prenom = "Tom",
                            DateNaissance = DateTime.Parse("2013-01-20"),
                            TrancheAge = "9-12 ans",
                            Adresse = "Avenue des tes mort, 69 évreux",
                            NumeroTelephone = "0253694587",
                            Email = "cmsv@outlook.com",
                            FicheSante = false,
                            StatutMC = "Membre",
                            Allergie = "RAS",
                            Commentaire = "C'est un petit con"
                        }
                    );
                    context.SaveChanges();

                }
                // Look for any Animateur.
                if (!context.Animateurs.Any())
                {

                    context.Animateurs.AddRange(
                        new Animateurs
                        {
                            Nom = "Capelle",
                            Prenom = "Alexandre",
                            DateNaissance = DateTime.Now,
                            ResponsableTrancheAge = "3-6 ans",
                            Adresse = "Avenue des tes mort, 69 évreux",
                            NumeroTelephone = "0253694587",
                            Email = "gpax@outlook.com",
                            Allergie = "RAS",
                            Commentaire = "C'est un petit con"
                        },
                        new Animateurs
                        {
                            Nom = "Sauvage",
                            Prenom = "Camille",
                            DateNaissance = DateTime.Parse("2000-01-20"),
                            ResponsableTrancheAge = "9-12 ans",
                            Adresse = "Avenue des tes mort, 69 évreux",
                            NumeroTelephone = "0253694587",
                            Email = "cmsv@outlook.com",
                            Allergie = "RAS",
                            Commentaire = "Je l'aime"
                        },
                        new Animateurs
                        {
                            Nom = "Tasset",
                            Prenom = "Némo",
                            DateNaissance = DateTime.Parse("2000-01-20"),
                            ResponsableTrancheAge = "9-12 ans",
                            Adresse = "Avenue des tes mort, 69 évreux",
                            NumeroTelephone = "0253694587",
                            Email = "cmsv@outlook.com",
                            Allergie = "RAS",
                            Commentaire = "il est bo"
                        },
                        new Animateurs
                        {
                            Nom = "Chais",
                            Prenom = "Elise",
                            DateNaissance = DateTime.Parse("2000-01-20"),
                            ResponsableTrancheAge = "9-12 ans",
                            Adresse = "Avenue des tes mort, 69 évreux",
                            NumeroTelephone = "0253694587",
                            Email = "cmsv@outlook.com",
                            Allergie = "RAS",
                            Commentaire = "Lol le chwing-gum"
                        }
                    );
                    context.SaveChanges();

                }
                if (!context.Plaines.Any())
                {
                    context.Plaines.AddRange(
                        new Plaines
                        {
                            NomPlaine = "Tournai 2",
                            DateDebut = DateTime.Parse("2023-07-20"),
                            DateFin = DateTime.Parse("2023-07-25"),
                            CapaciteMax = 70,

                        },
                        new Plaines
                        {
                            NomPlaine = "Tournai 1",
                            DateDebut = DateTime.Parse("2023-07-13"),
                            DateFin = DateTime.Parse("2023-07-18"),
                            CapaciteMax = 100,
                        },
                        new Plaines
                        {
                            NomPlaine = "Silly 1",
                            DateDebut = DateTime.Parse("2023-07-20"),
                            DateFin = DateTime.Parse("2023-07-25"),
                            CapaciteMax = 50,
                        }
                    );
                    context.SaveChanges();

                }
            }
        }
    }
}
