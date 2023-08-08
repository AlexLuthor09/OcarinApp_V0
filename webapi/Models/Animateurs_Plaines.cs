namespace OcarinAPI.Models
{
    public class Animateurs_Plaines
    {
        public int ID_animateur { get; set; }
        public int ID_plaine { get; set; }
        public string? ResponsableTrancheAge { get; set; }
        public bool? FicheSante { get; set; }

        public Animateurs? Animateurs { get; set; }
        public Plaines? Plaines { get; set; }
    }
}
