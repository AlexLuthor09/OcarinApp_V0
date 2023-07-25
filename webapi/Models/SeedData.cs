﻿using Microsoft.EntityFrameworkCore;
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
            using (var context = new OcarinAPIContext(serviceProvider.GetRequiredService<DbContextOptions<OcarinAPIContext>>()))
            {
                // Look for any Enfants.
                if (context.Enfants.Any())
                {
                    // DB has been seeded so no movies are added if there are one or more movies in the DB 
                }
                else
                {
                    context.Enfants.AddRange(
                        new Enfants
                        {
                            Nom = "PetitEnfant",
                            Prenom = "Marius",
                            DateNaissance = DateTime.Now,
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
                            DateNaissance = DateTime.Now,
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
                            DateNaissance = DateTime.Parse("2000-01-20"),
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
                if (context.Animateurs.Any())
                {
                    // DB has been seeded so no movies are added if there are one or more movies in the DB 
                }
                else
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
            }
        }
    }
}
