//using OpenQA.Selenium;
//using System.Collections.Generic;
//using System.Linq;


//namespace DesafioTotus.Helpers
//{
//    public class SelectCor
//    {
//        private IWebDriver driver;
//        private IWebElement selectWrapper;
//        private IEnumerable<IWebElement> opcoes;
//        public SelectCor(IWebDriver driver, By LocatorSelectWrapper)
//        {
//            this.driver = driver;
//            selectWrapper = driver.FindElement(LocatorSelectWrapper);
//            opcoes = selectWrapper.FindElements(By.Id("color_to_pick_list"));
//        }

//        public IEnumerable<IWebElement> Options => opcoes;


//        public void SelectByColor(string option)
//        {
//            opcoes
//                .Where(o => o.Text.Contains(option))
//                .ToList()
//                .ForEach(o =>
//                {
//                    o.Click();
//                });

//        }
//    }
//}
