using System;
using System.Threading.Tasks;

namespace CSharpTest.ApplicationServices
{
    public interface IOrderItemsService
    {
        Task<decimal> GetTotalBuys(DateTime dateTime);
    }
}