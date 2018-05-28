using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpTest.Model;

namespace CSharpTest.ApplicationServices
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> Find();
        Task<IEnumerable<Order>> Find(DateTime fittingDate);
        Task<IEnumerable<string>> GetOutwardPostCodes(DateTime fittingDate);
    }
}