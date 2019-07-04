using System.Net;
using System;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using FluentAssertions;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestSharpTest
{
    [TestClass]
    public class Clima
    {
        const string baseURL = "http://restapi.demoqa.com/utilities/weather/city/";

        [TestMethod]
        public void InfoClimaTest()
        {
            //Criando a conexão REST Client 
            RestClient restClient = new RestClient(baseURL);
            //restClient.BaseUrl = new Uri(baseURL);

            //Criando a request GET
            RestRequest restRequest = new RestRequest("Rio", Method.GET);

            //Criando e executando a response
            IRestResponse restResponse = restClient.Execute(restRequest);

            //Extraindo a saída de dados da response
            string response = restResponse.Content;

            //Validando a o status code 200
            try
            {
                NUnit.Framework.Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
            catch (AssertionException a)
            {
                string message = "Falha: ' " + new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name + " 'apresentou falha ao validar o Status Code. Erro: " + a.Message;
                Console.WriteLine(message);
                throw new AssertionException(message);
            }

            //Validando as informações da cidade passada na request
            if (!response.Contains("Rio"))
            {
                NUnit.Framework.Assert.Fail("As informações de clima não foram exibidas");
            }
        }
    }

    [TestClass]
    public class Clientes
    {
        const string baseURL = "https://jsonplaceholder.typicode.com/users";

        [TestMethod]
        public void VerificaStatusTest()
        {
            //Criando a conexão REST Client
            RestClient restClient = new RestClient(baseURL);

            //Criando a request GET
            RestRequest restRequest = new RestRequest("1", Method.GET);

            //Criando e executando a response
            IRestResponse restResponse = restClient.Execute(restRequest);

            //Validando a o status code da response
            NUnit.Framework.Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var deserializador = new JsonDeserializer();
            var saida = deserializador.Deserialize<Dictionary<string, string>>(restResponse);
            var resultado = saida["name"];

            NUnit.Framework.Assert.That(resultado, Is.EqualTo("Leanne Graham"), "Nome correto");
        }
    }

    [TestClass]
    public class Cep
    {
        const string baseURL = "http://viacep.com.br/ws/";
        const string cep = "23560470";

        private IRestResponse GetCEP(object CEP)
        {
            //Criando a conexão REST Client 
            RestClient restClient = new RestClient(baseURL + CEP + "/json/");

            //Criando a request GET
            RestRequest restRequest = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };

            return restClient.Execute(restRequest);
        }

        [TestMethod]
        public void InfoCepTest()
        {
            IRestResponse restResponse = GetCEP(23560470); 
            restResponse.StatusCode.Should().Be(200);
        }
    }

}
