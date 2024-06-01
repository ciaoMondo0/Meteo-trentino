using ModelliMeteo;
using System.ServiceModel;
namespace MeteoAPI.Services
{
    [ServiceContract]
    public interface IMeteoService
    {
        [OperationContract]
        public Task<Giorno> MeteoDelGiorno(string localita, DateTime giorno);
    }
}
