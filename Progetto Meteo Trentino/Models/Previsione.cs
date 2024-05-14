namespace Progetto_Meteo_Trentino.Models
{
    public class Previsione
    {
        public string localita { get; set; }
        public int quota { get; set; }
        public List<Giorno> giorni { get; set; }
    }
}
