using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharpTest.Helper;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestSharpTest.Tests.Clientes
{
    class ClientesObject
    {
        MassadeDadosHelper massa = new MassadeDadosHelper();
        TestHelper helper = new TestHelper();

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
