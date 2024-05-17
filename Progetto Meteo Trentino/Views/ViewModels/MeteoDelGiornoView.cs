using Progetto_Meteo_Trentino.Models;

namespace Progetto_Meteo_Trentino.Views.ViewModels
{
    public class MeteoDelGiornoView
    {
       public string localita {  get; set; }

       
       public Giorno giorno { get; set; }

      public List<Fasce> fasce { get; set; }
    }
}
