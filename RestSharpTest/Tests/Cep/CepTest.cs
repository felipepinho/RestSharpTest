using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestSharpTest.Tests.Cep
{
    [TestClass]
    public class CepTest
    {
        CepObject obj = new CepObject();

        [TestMethod]
        public void Valida_Cep_Status()
        {
            obj.VerificaStatus200();
        }
    }
}