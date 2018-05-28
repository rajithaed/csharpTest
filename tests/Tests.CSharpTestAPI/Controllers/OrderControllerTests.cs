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
    public class OrderControllerTests
    {
        private readonly Mock<IOrderService> _mockOrderService;

        public OrderControllerTests()
        {
            _mockOrderService = new Mock<IOrderService>();
        }

        [Test]
        public async Task GetOrders_should_return_list_of_orders()
        {
            var expected = new List<Order> {new Order(), new Order()};

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(x => x.Find()).ReturnsAsync(expected);

            var sut = new OrderController(mockOrderService.Object);

            var result = await sut.FindOrders();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task GivenFittingDate_WhenFindIsCalled_ThenReturnListOfOrders()
        {
            //Arrange
            var expected = new List<Order>
            {
                new Order {FittingDate = new DateTime(2018, 5, 12)},
                new Order {FittingDate = new DateTime(2018, 5, 12)}
            };
            _mockOrderService.Setup(x => x.Find(new DateTime(2018, 5, 12))).ReturnsAsync(expected);
            var sut = new OrderController(_mockOrderService.Object);

            //Act
            var result = await sut.FindOrders(new DateTime(2018, 5, 12));

            //Assert
            Assert.AreEqual(expected, result);
            Assert.IsInstanceOf<IEnumerable<Order>>(result);
            _mockOrderService.Verify(x => x.Find(It.IsAny<DateTime>()), Times.Exactly(1));
        }

        [Test]
        public async Task GivenFittingDate_WhenGetOutwardPostCodesIsCalled_ThenReturnListOfPostcodes()
        {
            //Arrange
            IEnumerable<string> expected = new List<string>();
            _mockOrderService.Setup(x => x.GetOutwardPostCodes(new DateTime(2018, 5, 12))).ReturnsAsync(expected);
            var sut = new OrderController(_mockOrderService.Object);

            //Act
            var result = await sut.GetOutwardPostCodes(It.IsAny<DateTime>());

            //Assert
            Assert.AreEqual(expected, result);
            Assert.IsInstanceOf<IEnumerable<string>>(result);
            _mockOrderService.Verify(x => x.GetOutwardPostCodes(It.IsAny<DateTime>()), Times.Exactly(1));
        }
    }
}