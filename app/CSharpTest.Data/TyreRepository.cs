using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpTest.Data.Context;
using CSharpTest.Model;

namespace CSharpTest.Data
{
    public class TyreRepository : ITyreRepository
    {
        private readonly IContextFactory<ICSharpTestContext> _contextFactory;

        public TyreRepository(IContextFactory<ICSharpTestContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Tyre>> GetAllTyres()
        {
            return await Task.Run(() =>
            {
                using (var context = _contextFactory.Create())
                {
                    return context.Tyres.ToList();
                }
            });
        }
    }
}