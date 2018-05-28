using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpTest.Model;

namespace CSharpTest.Data
{
    public interface ITyreRepository
    {
        Task<IEnumerable<Tyre>> GetAllTyres();
    }
}