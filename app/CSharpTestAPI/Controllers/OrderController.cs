using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CSharpTest.ApplicationServices;
using CSharpTest.Model;

namespace CSharpTestAPI.Controllers
{
    [RoutePrefix("api/v1")]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("orders")]
        public Task<IEnumerable<Order>> FindOrders()
        {
            return _orderService.Find();
        }

        [HttpGet]
        [Route("orders/{dateTime}")]
        public Task<IEnumerable<Order>> FindOrders(DateTime dateTime)
        {
            var result = _orderService.Find(dateTime);
            return result;
        }
       
        [HttpGet]
        [Route("orders/postcodes/{dateTime}")]
        public Task<IEnumerable<string>> GetOutwardPostCodes(DateTime dateTime)
        {
            var result = _orderService.GetOutwardPostCodes(dateTime);
            return result;
        }
    }
}