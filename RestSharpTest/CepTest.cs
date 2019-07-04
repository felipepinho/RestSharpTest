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
    public class CepTest
    {
        MassadeDadosHelper massa = new MassadeDadosHelper();
        TestHelper helper = new TestHelper();

        [TestMethod]
        public void VerificaStatus200()
        {
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