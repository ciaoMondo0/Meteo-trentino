namespace Progetto_Meteo_Trentino.Models
{
    public class RichiestaCitta
    {
        public string cittaSelezionata { get; set; }
        public List<string> CittaLista { get; set; } = new List<string>();
    }
}
