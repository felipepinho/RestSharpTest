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
    public class ClientesTest
    {
        MassadeDadosHelper massa = new MassadeDadosHelper();
        TestHelper helper = new TestHelper();

        [TestMethod]
        public void VerificaStatus200()
        {
            try
            {
                //Criando e executando a response
                IRestResponse restResponse = helper.Get(massa.baseClientesURL, massa.idCliente);

                //Validando o status code da response
                restResponse.StatusCode.Should().Be(200);
                
                //Validando o status code da response de outra forma
                NUnit.Framework.Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
            catch (AssertionException assert)
            {
                string message = "Falha: ' " + new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name + " ' apresentou falha ao validar o Status Code. Erro: " + assert.Message;
                Console.WriteLine(message);
                throw new AssertionException(message);
            }
        }

        [TestMethod]
        public void ValidarNomeCliente()
        {
            try
            {
                //Criando e executando a response
                IRestResponse restResponse = helper.Get(massa.baseClientesURL, massa.idCliente);

                var deserializador = new JsonDeserializer();
                var saida = deserializador.Deserialize<Dictionary<string, string>>(restResponse);
                var resultado = saida["name"];

                //Validando o se o nome do cliente é igual ao esperado
                NUnit.Framework.Assert.That(resultado, Is.EqualTo(massa.nomeCliente));
            }
            catch (AssertionException assert)
            {
                string message = "Falha: ' " + new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name + " ' apresentou falha ao validar o nome do cliente. Erro: " + assert.Message;
                Console.WriteLine(message);
                throw new AssertionException(message);
            }
        }
    }
}