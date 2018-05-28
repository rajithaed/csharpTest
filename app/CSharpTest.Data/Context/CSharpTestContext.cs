using System.Data.Entity;
using CSharpTest.Data.Configurations;
using CSharpTest.Model;

namespace CSharpTest.Data.Context
{
    public class CSharpTestContext : DbContext, ICSharpTestContext
    {
        private const string ConnectionString = "DefaultConnection";

        public CSharpTestContext()
            : base(ConnectionString)
        {
            Database.SetInitializer<CSharpTestContext>(null);

           // ToDo: If you need to use the seed method to populate your DB, use the line below
           // Database.SetInitializer<CSharpTestContext>(new CSharpTestDbInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new TyreConfiguration());
            modelBuilder.Configurations.Add(new OrderItemConfiguration());

            modelBuilder.Entity<Order>();
            modelBuilder.Entity<Tyre>();
            modelBuilder.Entity<OrderItem>();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Tyre> Tyres { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
       
    }
}