using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CSharpTest.ApplicationServices;
using CSharpTest.Model;

namespace CSharpTestAPI.Controllers
{
    [RoutePrefix("api/v1")]
    public class OrderItemsController : ApiController
    {
        private readonly IOrderItemsService _orderItemsService;

        public OrderItemsController(IOrderItemsService orderItemsService)
        {
            _orderItemsService = orderItemsService;
        }

        [HttpGet]
        [Route("orderitems/totalsales/{dateTime}")]
        public Task<decimal> GetTotalBuys(DateTime dateTime)
        {
            var result = _orderItemsService.GetTotalBuys(dateTime);
            return result;
        }
    }
}