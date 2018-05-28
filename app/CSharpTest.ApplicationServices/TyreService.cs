using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpTest.Data;
using CSharpTest.Model;

namespace CSharpTest.ApplicationServices
{
    public  class TyreService : ITyreService
    {
        private readonly ITyreRepository _tyreRepository;

        public TyreService(ITyreRepository tyreRepository)
        {
            _tyreRepository = tyreRepository;
        }

        public async Task<IEnumerable<Tyre>> GetAllTyres()
        {
            var allTyres = await _tyreRepository.GetAllTyres();
            IEnumerable<Tyre> orderdListOfTyres = allTyres.OrderBy(t => t.BuyPriceExVAT);
            return orderdListOfTyres;
        }
    }
}