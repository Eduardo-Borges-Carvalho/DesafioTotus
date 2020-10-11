using OpenQA.Selenium;

namespace DesafioTotus.PageObjects
{
    public class DashboardPO
    {
        private IWebDriver driver;
        private By ByCaixaPesquisa;
        private By ByBotaoPesquisa;
        private By ByItemPesquisado;


        public DashboardPO(IWebDriver driver)
        {
            this.driver = driver;
            ByCaixaPesquisa = By.Id("search_query_top");
            ByBotaoPesquisa = By.Name("submit_search");
            ByItemPesquisado = By.ClassName("product_img_link");
        }
        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/");
        }
        public void PesquisarProduto(string produto)
        {
            driver.FindElement(ByCaixaPesquisa).SendKeys(produto);
            driver.FindElement(ByBotaoPesquisa).Submit();

        }
        public void AcessarPaginaDoProduto()
        {
            driver.FindElement(ByItemPesquisado).Click();
        }
    }
}
