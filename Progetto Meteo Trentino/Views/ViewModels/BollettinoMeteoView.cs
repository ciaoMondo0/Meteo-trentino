using Progetto_Meteo_Trentino.Models;

namespace Progetto_Meteo_Trentino.Views.ViewModels
{
    public class BollettinoMeteoView
    {

        public string dataPubblicazione { get; set; }
        public int idPrevisione { get; set; }
        public string evoluzione { get; set; }
        public string evoluzioneBreve { get; set; }

        public List<Previsione> previsioni { get; set; }

    }
}
