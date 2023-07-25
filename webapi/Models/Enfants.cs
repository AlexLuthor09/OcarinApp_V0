namespace OcarinAPI.Models
{
    public class Enfants
    {
        public int ID { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string? TrancheAge { get; set; }
        public string? Adresse { get; set; }
        public string? NumeroTelephone { get; set; }
        public string? Email { get; set; }
        public bool? FicheSante { get; set; }
        public string? StatutMC { get; set; }
        public string? Allergie { get; set; }
        public string? Commentaire { get; set; }
    }
}
