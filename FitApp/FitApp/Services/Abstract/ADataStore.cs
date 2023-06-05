using FitAppApi;
using System.Net.Http;

namespace FitApp.Services.Abstract
{
    public class ADataStore
    {
        public FitApi _service;
        public ADataStore()
        {
            //Use this code to test locally - localhost do not have certificate
            var handler = new HttpClientHandler();
#if DEBUG
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
#endif
            var client = new HttpClient(handler);
            _service = new FitApi("https://localhost:7023", client);
        }
    }
}
