using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpTest.Data.Context;
using CSharpTest.Model;

namespace CSharpTest.Data
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly IContextFactory<ICSharpTestContext> _contextFactory;

        public OrderItemsRepository(IContextFactory<ICSharpTestContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems()
        {
            return await Task.Run(() =>
            {
                using (var context = _contextFactory.Create())
                {
                    return context.OrderItems.ToList();
                }
            });
        }
    }
}