using System.Data.Entity;
using CSharpTest.Model;

namespace CSharpTest.Data.Context
{
    public interface ICSharpTestContext : IContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Tyre> Tyres { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
    }
}