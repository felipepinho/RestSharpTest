using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;

namespace RestSharpTest
{
    [TestClass]
    public class Clima
    {
        [TestMethod]
        public void BuscaInfoClima()
        {
            //criando a conexao Client
            //RestClient restClient = new RestClient("http://restapi.demoqa.com/utilities/weather/city/");
            const string baseURL = "http://restapi.demoqa.com/utilities/weather/city/";
            RestClient restClient = new RestClient();
            restClient.BaseUrl = new Uri(baseURL);

            //Criando a request GET
            RestRequest restRequest = new RestRequest("Rio", Method.GET);

            //Executando a request e verificando a resposta
            IRestResponse restResponse = restClient.Execute(restRequest);

            //Extraindo a saída de dados da response
            string response = restResponse.Content;

            if (!response.Contains("Rio"))
            {
                Assert.Fail("As informações de clima não foram exibidas");
            }
        }
    }
}
