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
    public class OrderItemsServiceTests
    {
        private readonly Mock<IOrderItemsRepository> _mockOrderItemsRepository;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private IOrderItemsService _orderItemsService;


        public OrderItemsServiceTests()
        {
            _mockOrderItemsRepository = new Mock<IOrderItemsRepository>();
            _mockOrderRepository = new Mock<IOrderRepository>();
        }
        [Test]
        public async Task GivenAFittingDate_WhenGetTotalBuysIsCalled_ThenItemsRepositoryAndOrdersRepositoryBothAreCalled()
        {
            //Arrange
            var orderItems = GetSampleOrderItems();
            var orders = GetSampleOrders();
            _mockOrderRepository.Setup(x => x.Find(It.IsAny<DateTime>())).ReturnsAsync(orders);
            _mockOrderItemsRepository.Setup(x => x.GetOrderItems()).ReturnsAsync(orderItems);
            _orderItemsService = new OrderItemsService(_mockOrderItemsRepository.Object, _mockOrderRepository.Object);

            //Act
            await _orderItemsService.GetTotalBuys(It.IsAny<DateTime>());

            //Assert
            _mockOrderItemsRepository.Verify(x => x.GetOrderItems(), Times.AtLeast(1));
            _mockOrderRepository.Verify(x => x.Find(It.IsAny<DateTime>()), Times.AtLeast(1));
        }

        [Test]
        public async Task GivenAFittingDate_WhenGetTotalBuysIsCalled_ThenReturnTotalPriceFortheDay()
        {
            //Arrange
            var orderItems = GetSampleOrderItems();
            var ordersForTheDay = GetSampleOrders();
            _mockOrderRepository.Setup(x => x.Find(It.IsAny<DateTime>())).ReturnsAsync(ordersForTheDay);
            _mockOrderItemsRepository.Setup(x => x.GetOrderItems()).ReturnsAsync(orderItems);
            _orderItemsService = new OrderItemsService(_mockOrderItemsRepository.Object, _mockOrderRepository.Object);

            //Act
            var result = await _orderItemsService.GetTotalBuys(new DateTime(2018, 5, 12));

            //Assert
            Assert.IsInstanceOf<decimal>(result);
            Assert.AreEqual(300, result);
        }

        private static IEnumerable<OrderItem> GetSampleOrderItems()
        {
            return new List<OrderItem>
            {
                new OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    TyreId = 2,
                    Description = "YOKO 185R14C",
                    BuyPriceExVAT = 100M,
                    Quantity = 2
                },
                new OrderItem
                {
                    Id = 2,
                    OrderId = 2,
                    TyreId = 2,
                    Description = "MENTOR 185/65R14",
                    BuyPriceExVAT = 100M,
                    Quantity = 2
                },
                new OrderItem
                {
                    Id = 3,
                    OrderId = 1,
                    TyreId = 1,
                    Description = "MENTOR 185/65R14",
                    BuyPriceExVAT = 100M,
                    Quantity = 2
                },
                new OrderItem
                {
                    Id = 3,
                    OrderId = 3,
                    TyreId = 1,
                    Description = "MENTOR 185/65R14",
                    BuyPriceExVAT = 150M,
                    Quantity = 2
                }
            };
        }

        private static List<Order> GetSampleOrders()
        {
            var orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Created = new DateTime(2018, 5, 12),
                    CustomerName = "Raj",
                    FittingDate = new DateTime(2018, 5, 12)
                },
                new Order
                {
                    Id = 2,
                    Created = new DateTime(2018, 4, 8),
                    CustomerName = "Gareth",
                    FittingDate = new DateTime(2018, 5, 12)
                }
            };
            return orders;
        }
    }
}