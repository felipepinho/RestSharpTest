using RestSharp;

namespace RestSharpTest
{
    public class TestHelper
    {
        MassadeDadosHelper massa = new MassadeDadosHelper();

        public void MontaUrlCep()
        {

        }

        public IRestResponse GetCEP(string URL, string CEP)
        {
            //Criando a conexão REST Client 
            RestClient restClient = new RestClient(URL + CEP + "/json/");

            //Criando a request GET
            RestRequest restRequest = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };

            return restClient.Execute(restRequest);
        }

        public IRestResponse Get(string URL, string valor)
        {
            //Criando a conexão REST Client 
            RestClient restClient = new RestClient(URL);

            //Criando a request GET
            RestRequest restRequest = new RestRequest(valor, Method.GET) { RequestFormat = DataFormat.Json };

            return restClient.Execute(restRequest);
        }

    }
}

