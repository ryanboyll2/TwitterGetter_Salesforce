using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterGetter;
using TwitterGetter.Controllers;
using TwitterGetter.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TwitterGetter.Tests.Controllers
{
    [TestClass]
    public class TwitterControllerTest
    {
        [TestMethod]
        public async Task GetWithNoFilter()
        {
            // Arrange
            TwitterController controller = new TwitterController();
            int testCount = 10;
            string testUser = "Salesforce";

            // Act
            IEnumerable<Tweet> result = await controller.Get(testUser, testCount, string.Empty);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count());
        }

        [TestMethod]
        public async Task GetWithFakeFilter()
        {
            // Arrange
            TwitterController controller = new TwitterController();
            int testCount = 10;
            string testUser = "Salesforce";
            string filter = "not_gonna_find_it";

            // Act
            IEnumerable<Tweet> result = await controller.Get(testUser, testCount, filter);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
