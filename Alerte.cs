using System.ComponentModel.DataAnnotations;

namespace ProjetAlerte.Database.Models
{
    public class Alerte
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [StringLength(100, ErrorMessage = "Le titre ne peut dépasser 100 caractères")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "La description est obligatoire")]
        public string Description { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude invalide")]
        public double Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Longitude invalide")]
        public double Longitude { get; set; }

        public string NiveauDanger { get; set; } = "Moyen";
        public string Statut { get; set; } = "Nouveau";
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
    }
}