using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpTest.Model;

namespace CSharpTest.Data
{
    public interface IOrderItemsRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItems();
    }
}