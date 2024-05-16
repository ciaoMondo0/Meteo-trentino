using Progetto_Meteo_Trentino.Models;
using System;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using System.Text.Json;

namespace Progetto_Meteo_Trentino.Services
{
    public  class MeteoService : IMeteoService
    {
       
        public  async Task<Bollettino> Meteo() {


            string url = $"https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=";
            ;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Bollettino bollettino = JsonSerializer.Deserialize<Bollettino>(json);
                    return bollettino;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public async Task<Previsione> PrevisioneLuogo(string localita)
        {
            var bollettino = await Meteo();
            if (bollettino != null)
            {
                var previsioneLocalita = bollettino.previsione.FirstOrDefault(p => p.localita.Equals(localita, StringComparison.OrdinalIgnoreCase));
                if (previsioneLocalita != null)
                {
                    return new Previsione
                    {
                        localita = previsioneLocalita.localita,
                        quota = previsioneLocalita.quota,
                        giorni = previsioneLocalita.giorni
                    };
                }
            }
            return null;

        }

        public async Task<Giorno> MeteoDelGiorno(string localita, DateTime data)
        {
            var previsione = await PrevisioneLuogo(localita);
            if (previsione != null)
            {
                Giorno giorno = previsione.giorni.FirstOrDefault(g => g.giorno.Date == data);
                if (giorno != null)
                {
                    return new Giorno
                    {
                        idPrevisioneGiorno = giorno.idPrevisioneGiorno,
                        giorno = giorno.giorno,
                        idIcona = giorno.idIcona,
                        icona = giorno.icona,
                        descIcona = giorno.icona,
                        testoGiorno = giorno.testoGiorno,
                        tMinGiorno = giorno.tMinGiorno,
                        tMaxGiorno = giorno.tMaxGiorno,
                        fasce = giorno.fasce

                    };
                } else
                {
                    return null;
                }
                  
            }
            else
            {
                return null;
            }

        }



    }
        
    }

