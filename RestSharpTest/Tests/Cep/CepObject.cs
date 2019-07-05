using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using RestSharpTest.Helper;
using System;
using System.Net;

namespace RestSharpTest.Tests.Cep
{
    class CepObject 
    {
        public void VerificaStatus200()
        {
            MassadeDadosHelper massa = new MassadeDadosHelper();
            TestHelper helper = new TestHelper();
            try
            {
                //Criando e executando a response
                IRestResponse restResponse = helper.GetCEP(massa.baseCepURL, massa.cep);

                //Validando o status code da response
                restResponse.StatusCode.Should().Be(200);

                //Validando o status code da response de outra forma
                NUnit.Framework.Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
            catch (Exception e)
            {
                string message = "Falha: ' " + new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name + " ' apresentou falha ao validar o Status Code. Erro: " + e.Message;
                Console.WriteLine(message);
                throw new AssertionException(message);
            }
        }
    }
}