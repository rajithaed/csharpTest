using System;
using System.Linq;
using System.Threading.Tasks;
using CSharpTest.Data;

namespace CSharpTest.ApplicationServices
{
    public class OrderItemsService : IOrderItemsService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IOrderRepository _ordersRepository;

        public OrderItemsService(IOrderItemsRepository orderItemsRepository, IOrderRepository ordersRepository)
        {
            _orderItemsRepository = orderItemsRepository;
            _ordersRepository = ordersRepository;
        }

        public async Task<decimal> GetTotalBuys(DateTime dateTime)
        {
            var ordersForTheDay = await _ordersRepository.Find(dateTime);
            var orderItems = await _orderItemsRepository.GetOrderItems();

            var orders = ordersForTheDay.ToList();

            return (from item in orderItems
                from order in orders
                where item.OrderId.Equals(order.Id)
                select item.BuyPriceExVAT).Sum();
        }
    }
}