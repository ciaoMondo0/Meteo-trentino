using Progetto_Meteo_Trentino.Models;
using System;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using System.Text.Json;

namespace Progetto_Meteo_Trentino.Services
{
    public static class MeteoService
    {
       
        public static async Task<Bollettino> Meteo(string localita) {


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


      
    }
        
    }

