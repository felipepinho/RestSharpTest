using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestSharpTest.Tests.Clientes
{
    [TestClass]
    public class ClientesTest
    {
        ClientesObject obj = new ClientesObject();

        [TestMethod]
        public void Valida_Cliente_Status()
        {
            obj.VerificaStatus200();
        }

        [TestMethod]
        public void Valida_Cliente_Nome()
        {
            obj.ValidarNomeCliente();
        }
    }
}