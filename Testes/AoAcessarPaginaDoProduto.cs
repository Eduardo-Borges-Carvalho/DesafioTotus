using OpenQA.Selenium;
using Xunit;
using DesafioTotus.Fixtures;
using DesafioTotus.PageObjects;
using System.Collections.Generic;
using System.Threading;
using System;

namespace DesafioTotus.Testes
{
    [Collection("Chrome Driver")]
    public class AoAcessarPaginaDoProduto
    {
        private IWebDriver driver;

        public AoAcessarPaginaDoProduto(TestFixture fixture)
        {
            driver = fixture.Driver;
        }
        [Fact]
        public void DadoAcessoAPaginaDoProdutoDevePermitirEscolherACor()
        {
            //Arrange
            var DashboardPO = new DashboardPO(driver);
            DashboardPO.Visitar();
            DashboardPO.PesquisarProduto("T-shirt");
            DashboardPO.AcessarPaginaDoProduto();
            //Act
            var ProdutoPO = new ProdutoPO(driver);
            ProdutoPO.EscolherACorDoProduto();
            //Assert
            IWebElement corSelecionada = driver.FindElement(By.XPath("//*[@id='color_to_pick_list']/li[2]"));
            String estadoDoElemento = corSelecionada.GetAttribute("class");
            Assert.Contains("selected", estadoDoElemento);
            Thread.Sleep(3000);
        }
        [Fact]
        public void DadoEscolhaDoProdutoDevePermitirEnviarAoCarrinho()
        {
            //Arrange
            var DashboardPO = new DashboardPO(driver);
            DashboardPO.Visitar();
            DashboardPO.PesquisarProduto("T-shirt");
            DashboardPO.AcessarPaginaDoProduto();
            var ProdutoPO = new ProdutoPO(driver);
            ProdutoPO.EscolherACorDoProduto();
            //Act
            ProdutoPO.AdicionarAoCarrinho();
            //Assert
            IWebElement textoItemAdicionado = driver.FindElement(By.XPath("//*[@id='layer_cart']//div[1]/h2"));
            Thread.Sleep(3000);
            Assert.Contains("Product successfully added to your shopping cart", textoItemAdicionado.Text);
            Thread.Sleep(3000);
        }
        [Fact]
        public void DadoProdutoNoCarrinhoDeveValidarOsDadosDoItem()
        {
            //Arrange
            var DashboardPO = new DashboardPO(driver);
            DashboardPO.Visitar();
            DashboardPO.PesquisarProduto("T-shirt");
            DashboardPO.AcessarPaginaDoProduto();
            var ProdutoPO = new ProdutoPO(driver);
            ProdutoPO.EscolherACorDoProduto();
            //Act
            ProdutoPO.AdicionarAoCarrinho();
            ProdutoPO.AcessarCarrinho();
            //Assert
            IWebElement itemNome = driver.FindElement(By.XPath("//*[@id='product_1_2_0_0']//p/a"));
            IWebElement itemQuantidade = driver.FindElement(By.XPath("//*[@id='product_1_2_0_0']//input[2]"));
            IWebElement itemValor = driver.FindElement(By.XPath("//*[@id='product_price_1_2_0']/span"));
            Assert.Contains("Faded Short Sleeve T-shirts", itemNome.Text);
            Assert.Contains("1", itemQuantidade.GetAttribute("value"));  //GetCssValue
            Assert.Contains("$16.51", itemValor.Text);
        }
        [Fact]
        public void DadoUmSegundoProdutoNoCarrinhoDeveValidarOsDadosDosItens()
        {
            //Arrange
            var DashboardPO = new DashboardPO(driver);
            //Primeiro produto
            DashboardPO.Visitar();
            DashboardPO.PesquisarProduto("T-shirt");
            DashboardPO.AcessarPaginaDoProduto();
            var ProdutoPO = new ProdutoPO(driver);
            ProdutoPO.EscolherACorDoProduto();
            ProdutoPO.AdicionarAoCarrinho();
            //Segundo Produto
            DashboardPO.Visitar();
            DashboardPO.PesquisarProduto("Blouse");
            DashboardPO.AcessarPaginaDoProduto();
            ProdutoPO.AdicionarAoCarrinho();

            //Act
            ProdutoPO.AcessarCarrinho();

            //Assert
            //Primeiro item
            IWebElement itemNome = driver.FindElement(By.XPath("//*[@id='product_1_2_0_0']//p/a"));
            IWebElement itemQuantidade = driver.FindElement(By.XPath("//*[@id='product_1_2_0_0']//input[2]"));
            IWebElement itemValor = driver.FindElement(By.XPath("//*[@id='product_price_1_2_0']/span"));
            //Segundo item
            IWebElement itemNome2 = driver.FindElement(By.XPath("//*[@id='product_2_7_0_0']//p/a"));
            IWebElement itemQuantidade2 = driver.FindElement(By.XPath("//*[@id='product_2_7_0_0']//input[2]"));
            IWebElement itemValor2 = driver.FindElement(By.XPath("//*[@id='product_price_2_7_0']/span"));
            //primeiro item
            Assert.Contains("Faded Short Sleeve T-shirts", itemNome.Text);
            Assert.Contains("1", itemQuantidade.GetAttribute("value"));  //GetCssValue
            Assert.Contains("$16.51", itemValor.Text);
            //segundo item
            Assert.Contains("Blouse", itemNome2.Text);
            Assert.Contains("1", itemQuantidade2.GetAttribute("value"));  //GetCssValue
            Assert.Contains("$27.00", itemValor2.Text);
        }
    }
}
