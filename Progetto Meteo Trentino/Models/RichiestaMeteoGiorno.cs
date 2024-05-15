using System.ComponentModel.DataAnnotations;

namespace Progetto_Meteo_Trentino.Models
{
    public class RichiestaMeteoGiorno
    {
        public string citta {  get; set; }

        [DataType(DataType.Date)]
        public DateTime giorno { get; set; }
    }
}
