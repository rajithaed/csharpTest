using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CSharpTest.Data.Context;
using CSharpTest.Model;

namespace CSharpTest.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IContextFactory<ICSharpTestContext> _contextFactory;

        public OrderRepository(IContextFactory<ICSharpTestContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Order>> Find()
        {
            return await Task.Run(() =>
            {
                using (var context = _contextFactory.Create())
                {
                    return context.Orders.ToList();
                }
            });
        }

        public async Task<IEnumerable<Order>> Find(DateTime fittingDate)
        {
            return await Task.Run(() =>
            {
                using (var context = _contextFactory.Create())
                {
                    return context.Orders.Where(o => o.FittingDate == fittingDate).ToList();
                }
            });
        }

        public async Task<IEnumerable<string>> GetOutwardPostCodes(DateTime fittingDate)
        {
            return await Task.Run(() =>
            {
                using (var context = _contextFactory.Create())
                {
                    var postcodes = new List<string>();
                    var orders = context.Orders.Where(o => o.FittingDate == fittingDate);
                    foreach (var order in orders) postcodes.Add(order.FittingPostcode);
                    return postcodes;
                }
            });
        }
    }
}