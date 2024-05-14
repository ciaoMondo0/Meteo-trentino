namespace Progetto_Meteo_Trentino.Models
{
    public class Bollettino
    {
        public string fonteDaCitare { get; set; }
        public string codiceIpaTitolare { get; set; }
        public string nomeTitolare { get; set; }
        public string codiceIpaEditore { get; set; }
        public string nomeEditore { get; set; }
        public string dataPubblicazione { get; set; }
        public int idPrevisione { get; set; }
        public string evoluzione { get; set; }
        public string evoluzioneBreve { get; set; }
        public List<object> allerteList { get; set; }
        public List<Previsione> previsioni { get; set; }
    }
}
