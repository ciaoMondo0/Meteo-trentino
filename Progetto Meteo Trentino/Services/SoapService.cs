using Progetto_Meteo_Trentino.Models;

namespace Progetto_Meteo_Trentino.Services
{
    public class SoapService
    {



        public List<Previsione> previsioni(string localita, DateTime data)
        {
            Bollettino bollettino = MeteoService.Meteo(localita).Result;
            if(bollettino != null)
            {
                List<Previsione> previsioni = bollettino.previsioni
                    .Where(p => p.giorni.Any(g => g.giorno == data))
                    .ToList();


                return previsioni;

            }
            else
            {
                return null;
            }

        }
    }
}
