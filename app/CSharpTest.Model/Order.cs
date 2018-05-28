using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpTest.Model
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string CustomerName { get; set; }
        public DateTime FittingDate { get; set; }
        public string FittingPostcode { get; set; }
    }
}