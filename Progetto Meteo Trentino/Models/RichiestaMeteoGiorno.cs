using System.ComponentModel.DataAnnotations;

namespace Progetto_Meteo_Trentino.Models
{
    public class RichiestaMeteoGiorno
    {
        public string cittaSelezionata { get; set; }
        public List<string> CittaLista { get; set; } = new List<string>();

        [DataType(DataType.Date)]
        public DateTime giorno { get; set; }
    }
}
