namespace OcarinAPI.Models
{
    public class Inscription
    {
        public int ID { get; set; }
        public int EnfantID { get; set; }
        public int PlaineID { get; set; }
        public DateTime DateInscription { get; set; }
        public string? StatutPaiement { get; set; }
    }
}
