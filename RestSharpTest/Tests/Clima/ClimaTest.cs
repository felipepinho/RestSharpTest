using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestSharpTest.Tests.Clima
{
    [TestClass]
    public class ClimaTest
    {
        ClimaObject obj = new ClimaObject();

        [TestMethod]
        public void Valida_Clima_Status()
        {
            obj.VerificaStatus200();
        }

        [TestMethod]
        public void Valida_Clima_Exibicao()
        {
            obj.VerificaExibicao();
        }
    }
}
