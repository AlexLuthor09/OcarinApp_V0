namespace OcarinAPI.Models
{
    public class Taches_Plaines
    {
        public int ID_plaine { get; set; }
        public int ID_tache { get; set; }
        public Taches? Taches { get; set; }
        public Plaines? Plaines { get; set; }
    }
}
