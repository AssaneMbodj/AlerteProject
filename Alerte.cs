namespace WebApp.Models
{
    public class Alerte
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Type { get; set; } // Agression, incendie, etc.
        public string Description { get; set; }
        public string Lieu { get; set; }
        public string NiveauDanger { get; set; } // Faible, moyen, élevé
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string UtilisateurId { get; set; }
       
    }
}
