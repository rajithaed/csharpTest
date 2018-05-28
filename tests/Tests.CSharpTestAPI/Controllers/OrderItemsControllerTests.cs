using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpTest.ApplicationServices;
using CSharpTest.Model;
using CSharpTestAPI.Controllers;
using Moq;
using NUnit.Framework;

namespace Tests.CSharpTestAPI.Controllers
{
    [TestFixture]
    public class OrderItemsControllerTests
    {
        private readonly Mock<IOrderItemsService> _mockOrderIitemsService;

        public OrderItemsControllerTests()
        {
            _mockOrderIitemsService = new Mock<IOrderItemsService>();
        }

        [Test]
        public async Task GivenFittingDate_WhenGetTotalBuysIsCalled_ThenReturnTotalPriceAsDecimal()
        {
            //Arrange
            _mockOrderIitemsService.Setup(x => x.GetTotalBuys(new DateTime(2018, 5, 12))).ReturnsAsync(It.IsAny<decimal>());
            var sut = new OrderItemsController(_mockOrderIitemsService.Object);

            //Act
            var result = await sut.GetTotalBuys(It.IsAny<DateTime>());

            //Assert
            Assert.AreEqual(It.IsAny<decimal>(), result);
            Assert.IsInstanceOf<decimal>(result);
            _mockOrderIitemsService.Verify(x => x.GetTotalBuys(It.IsAny<DateTime>()), Times.Exactly(1));
        }
    }
}