using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CSharpTest.Model;

namespace CSharpTest.Data.Configurations
{
    public class TyreConfiguration : EntityTypeConfiguration<Tyre>
    {
        public TyreConfiguration()
        {
            HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).HasMaxLength(100).IsRequired();
            Property(x => x.BuyPriceExVAT).IsRequired();
        }
    }
}