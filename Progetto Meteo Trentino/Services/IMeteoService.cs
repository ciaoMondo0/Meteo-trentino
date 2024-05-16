using Progetto_Meteo_Trentino.Models;
using System.ServiceModel;
namespace Progetto_Meteo_Trentino.Services
{
    [ServiceContract]
    public interface IMeteoService
    {
        [OperationContract]
        public Task<Giorno> MeteoDelGiorno(string localita, DateTime giorno);
    }
}
