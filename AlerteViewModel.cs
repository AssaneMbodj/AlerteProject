namespace ProjetAlerte.Web.ViewModels
{
    public class AlerteViewModel
    {
        public string Titre { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string NiveauDanger { get; set; }
    }
}