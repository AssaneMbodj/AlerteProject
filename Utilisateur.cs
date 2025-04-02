namespace WebApp.Models
{
    public class Utilisateur
    {
        public int id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Role { get; set; } // Utilisateur ou Autorité
    }
}
