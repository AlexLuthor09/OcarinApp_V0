namespace OcarinAPI.Models.ModelsNotDB
{
    public class AnimateurPlaines
    {
        public int ID_animateur { get; set; }
        public int ID_plaine { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; } 
        public string NumeroTelephone { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string Allergie { get; set; }
        public string Commentaire { get; set; }
        public string AnneeFormation { get; set; }
        public string ResponsableTrancheAge { get; set; }
        public bool FicheSante { get; set; }
    }
}
