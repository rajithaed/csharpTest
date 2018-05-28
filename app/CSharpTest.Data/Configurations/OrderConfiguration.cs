using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CSharpTest.Model;

namespace CSharpTest.Data.Configurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CustomerName).HasMaxLength(100);
            Property(x => x.FittingDate).IsRequired();
            Property(x => x.FittingPostcode).HasMaxLength(7);
            Property(x => x.Created).IsRequired();
        }        
    }
}
