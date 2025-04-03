using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjetAlerte.Database.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut excéder 50 caractères")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le téléphone est obligatoire")]
        [Phone(ErrorMessage = "Format de téléphone invalide")]
        public string Telephone { get; set; }

        public DateTime DateInscription { get; set; } = DateTime.UtcNow;
        public ICollection<Alerte> Alertes { get; set; }
    }
}