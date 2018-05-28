using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpTest.Model;

namespace CSharpTest.ApplicationServices
{
    public interface ITyreService
    {
        Task<IEnumerable<Tyre>> GetAllTyres();
    }
}