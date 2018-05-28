using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpTest.ApplicationServices;
using CSharpTest.Data;
using CSharpTest.Model;
using Moq;
using NUnit.Framework;

namespace Tests.CSharpTest.ApplicationServices
{
    [TestFixture]
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private IOrderService _orderService;


        public OrderServiceTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
        }

        [Test]
        public async Task Get_should_return_all_orders()
        {
            //Arrange
            var expected = new List<Order> {new Order(), new Order()};
            _mockOrderRepository.Setup(x => x.Find()).ReturnsAsync(expected);
            var sut = new OrderService(_mockOrderRepository.Object);

            //Act
            var result = await sut.Find();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task GivenAFittingDate_WhenFindOrdersIsCalled_ThenRepositoryIsCalled()
        {
            //Arrange
            var expected = new List<Order> {new Order(), new Order()};
            _mockOrderRepository.Setup(x => x.Find(new DateTime())).ReturnsAsync(expected);
            _orderService = new OrderService(_mockOrderRepository.Object);

            //Act
            await _orderService.Find(new DateTime());

            //Assert
            _mockOrderRepository.Verify(x => x.Find(It.IsAny<DateTime>()), Times.AtLeastOnce);
        }


        [Test]
        public async Task GivenAFittingDate_WhenFindOrdersIsCalled_ThenReturnListOfOrfers()
        {
            //Arrange
            var expected = new List<Order> {new Order(), new Order()};
            _mockOrderRepository.Setup(x => x.Find(new DateTime())).ReturnsAsync(expected);
            _orderService = new OrderService(_mockOrderRepository.Object);

            //Act
            var result = await _orderService.Find(new DateTime());

            //Assert
            Assert.IsInstanceOf<IEnumerable<Order>>(result);
        }

        [Test]
        public async Task GivenAFittingDate_WhenFindOrdersIsCalled_ThenReturnListOfOrfersForGivenDates()
        {
            //Arrange
            var fittingDate = new DateTime(2018, 5, 25);
            var orders = GetSampleOrders();
            _mockOrderRepository.Setup(x => x.Find(fittingDate)).ReturnsAsync(orders);
            _orderService = new OrderService(_mockOrderRepository.Object);

            //Act
            var result = await _orderService.Find(fittingDate);

            //Assert
            Assert.IsInstanceOf<IEnumerable<Order>>(result);
            var expected = orders.Where(x => x.FittingDate == fittingDate);
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public async Task GivenAFittingDate_WhenGetOutwardPostCodesIsCalled_ThenRepositoryIsCalled()
        {
            //Arrange
            IEnumerable<string> postcodes = new List<string> { "BL4 7DJ", "M1 3TL" };
            _mockOrderRepository.Setup(x => x.GetOutwardPostCodes(new DateTime())).ReturnsAsync(postcodes);
            _orderService = new OrderService(_mockOrderRepository.Object);

            //Act
            await _orderService.GetOutwardPostCodes(It.IsAny<DateTime>());

            //Assert
            _mockOrderRepository.Verify(x => x.GetOutwardPostCodes(It.IsAny<DateTime>()), Times.Exactly(1));
        }

        [Test]
        public async Task GivenAFittingDate_WhenGetOutwardPostCodesIsCalled_ThenReturnListOfPostCodes()
        {
            //Arrange
            var fittingDate = new DateTime(2018, 5, 25);
            IEnumerable<string> postcodes = new List<string> {"BL4 7DJ", "M1 3TL"};
            _mockOrderRepository.Setup(x => x.GetOutwardPostCodes(fittingDate)).ReturnsAsync(postcodes);
            _orderService = new OrderService(_mockOrderRepository.Object);

            //Act
            var result = await _orderService.GetOutwardPostCodes(fittingDate);

            //Assert
            Assert.IsInstanceOf<IEnumerable<string>>(result);
            Assert.AreEqual(postcodes, result);
        }


        private static List<Order> GetSampleOrders()
        {
            var orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Created = new DateTime(2018, 4, 10),
                    CustomerName = "Raj",
                    FittingDate = new DateTime(2018, 5, 25)
                },
                new Order
                {
                    Id = 2,
                    Created = new DateTime(2018, 4, 8),
                    CustomerName = "Gareth",
                    FittingDate = new DateTime(2018, 5, 25)
                },
                new Order
                {
                    Id = 3,
                    Created = new DateTime(2018, 3, 21),
                    CustomerName = "Duco",
                    FittingDate = new DateTime(2018, 5, 25)
                },
                new Order
                {
                    Id = 4,
                    Created = new DateTime(2018, 3, 12),
                    CustomerName = "Simon",
                    FittingDate = new DateTime(2018, 5, 25)
                },
                new Order
                {
                    Id = 5,
                    Created = new DateTime(2018, 4, 10),
                    CustomerName = "Chris",
                    FittingDate = new DateTime(2018, 5, 25)
                }
            };
            return orders;
        }
    }
}