using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CSharpTest.Model;

namespace CSharpTest.Data.Configurations
{
    public class OrderItemConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfiguration()
        {
            HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).IsRequired();
            Property(x => x.TyreId).IsRequired();
            Property(x => x.Description).HasMaxLength(50);
            Property(x => x.BuyPriceExVAT).IsRequired();
            Property(x => x.Quantity).IsRequired();
        }
    }
}