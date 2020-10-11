using OpenQA.Selenium;


namespace DesafioTotus.PageObjects
{
    public class ProdutoPO
    {
        private IWebDriver driver;
        private By ByCorAzul;
        private By ByBtnAdicionarAoCarrinho;
        private By ByBtnAcessoAoCarrinho;
        //Camada do carrinho
        //private By ByItemNome;
        //private By ByItemCor;
        //private By ByQuantidade;

        public ProdutoPO(IWebDriver driver)
        {
            this.driver = driver;
            ByCorAzul = By.Id("color_14");
            ByBtnAdicionarAoCarrinho = By.Id("add_to_cart");
            ByBtnAcessoAoCarrinho = By.CssSelector("[title='Proceed to checkout']");
            ////Camada do carrinho
            //ByItemNome = By.Id("layer_cart_product_title");
            //ByItemCor = By.Id("layer_cart_product_attributes");
            //ByQuantidade = By.Id("layer_cart_product_quantity");

        }

        public void EscolherACorDoProduto()
        {
            driver.FindElement(ByCorAzul).Click();
        }

        public void AdicionarAoCarrinho()
        {
            driver.FindElement(ByBtnAdicionarAoCarrinho).Click();
        }
        public void AcessarCarrinho()
        {
            driver.FindElement(ByBtnAcessoAoCarrinho).Click();
        }
        
    }
}
