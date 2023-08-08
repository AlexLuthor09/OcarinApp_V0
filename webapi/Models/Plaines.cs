namespace OcarinAPI.Models
{
    public class Plaines
    {
        public int ID_plaine { get; set; }
        public string? NomPlaine { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int? CapaciteMax { get; set; }
        public string? TableauTaches { get; set; }
    }
}
