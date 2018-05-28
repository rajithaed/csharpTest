using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpTest.Data;
using CSharpTest.Model;

namespace CSharpTest.ApplicationServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly decimal _vatPercentage = 20;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> Find()
        {
            return await _orderRepository.Find();
        }

        public async Task<IEnumerable<Order>> Find(DateTime fittingDate)
        {
            return await _orderRepository.Find(fittingDate);
        }
        public async Task<IEnumerable<string>> GetOutwardPostCodes(DateTime fittingDate)
        {
            return await _orderRepository.GetOutwardPostCodes(fittingDate);
        }
    }
}