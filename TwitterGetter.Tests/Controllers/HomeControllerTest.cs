using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterGetter;
using TwitterGetter.Controllers;

namespace TwitterGetter.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Twitter Getter 2017", result.ViewBag.Title);
        }
    }
}
