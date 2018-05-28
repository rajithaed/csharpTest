using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpTest.Model
{
    [Table("Tyres")]
    public class Tyre
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal BuyPriceExVAT { get; set; }
    }
}