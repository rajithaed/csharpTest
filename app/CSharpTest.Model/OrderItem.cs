using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpTest.Model
{
    [Table("OrderItems")]
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TyreId { get; set; }
        public string Description { get; set; }
        public decimal BuyPriceExVAT { get; set; }
        public int Quantity { get; set; }
    }
}