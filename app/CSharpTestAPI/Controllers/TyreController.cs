using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CSharpTest.ApplicationServices;
using CSharpTest.Model;

namespace CSharpTestAPI.Controllers
{
    [RoutePrefix("api/v1")]
    public class TyreController : ApiController
    {
        private readonly ITyreService _tyreService;

        public TyreController(ITyreService tyreService)
        {
            _tyreService = tyreService;
        }

        [HttpGet]
        [Route("tyres")]
        public Task<IEnumerable<Tyre>> GetAllTyres()
        {
            return _tyreService.GetAllTyres();
        }
    }
}