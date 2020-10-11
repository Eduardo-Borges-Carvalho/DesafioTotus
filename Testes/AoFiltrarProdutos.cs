using OpenQA.Selenium;
using Xunit;
using DesafioTotus.Fixtures;
using DesafioTotus.PageObjects;
using System.Collections.Generic;
using System.Threading;

namespace DesafioTotus.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarProdutos
    {
        private IWebDriver driver;

        public AoFiltrarProdutos(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoBuscaPorProdutoValidoDeveMostrarResultadoDaPesquisa()
        {
            //Arrange
            var DashboardPO = new DashboardPO(driver);
            DashboardPO.Visitar();
            //Act
            DashboardPO.PesquisarProduto("T-shirt");
            //Assert
            Assert.Contains("Faded Short Sleeve T-shirts", driver.PageSource);
            Thread.Sleep(3000);
        }
        [Fact]
        public void DadoBuscaPorProdutoValidoDevePermitirAcessarPaginaDoProduto()
        {
            //Arrange
            var DashboardPO = new DashboardPO(driver);
            DashboardPO.Visitar();
            DashboardPO.PesquisarProduto("T-shirt");
            //Act
            DashboardPO.AcessarPaginaDoProduto();
            //Assert
            Assert.Contains("Data sheet", driver.PageSource);
            Thread.Sleep(3000);
        }


    }
}
