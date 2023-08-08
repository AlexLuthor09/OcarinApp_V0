namespace OcarinAPI.Models
{
    public class Enfants_Plaines
    {
        public int ID_plaine { get; set; }
        public int ID_enfant { get; set;}
        public int? nbrJourPresent { get; set; }
        public bool? StatutPaiement { get; set; }
        public bool? lundi { get; set; }
        public bool? mardi { get; set; }
        public bool? mercredi { get; set; }
        public bool? jeudi { get; set; }
        public bool? vendredi { get; set; }
        public DateTime DateInscription { get; set; } = DateTime.UtcNow;
        public Plaines? Plaines { get; set; }
        public Enfants? Enfants { get; set; }
    }
}
