using ModelliMeteo;

namespace Progetto_Meteo_Trentino.ViewModels
{
    public class MeteoDelGiornoView
    {
        public string localita { get; set; }


        public Giorno giorno { get; set; }

        public List<Fasce> fasce { get; set; }
    }
}
