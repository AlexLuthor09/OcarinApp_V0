﻿namespace OcarinAPI.Models
{
    public class Animateurs
    {
        public int ID_animateur { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string? Adresse { get; set; }
        public string? NumeroTelephone { get; set; }
        public string? Email { get; set; }
        public string? Allergie { get; set; }
        public string? Commentaire { get; set; }
        public string? AnneeFormation { get; set;}
    }
}
