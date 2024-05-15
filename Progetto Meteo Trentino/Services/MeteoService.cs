using Progetto_Meteo_Trentino.Models;
using System;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using System.Text.Json;

namespace Progetto_Meteo_Trentino.Services
{
    public  class MeteoService
    {
       
        public  async Task<Bollettino> Meteo(string localita) {


            string url = $"https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita={localita}";
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

        public async Task<Giorno> MeteoDelGiorno(string localita, DateTime data)
        {
            var bollettino = await Meteo(localita);
            if (bollettino != null)
            {
                Giorno giorno = bollettino.previsione.SelectMany(p => p.giorni).Where(g=> g.giorno.Date == data).FirstOrDefault();
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

