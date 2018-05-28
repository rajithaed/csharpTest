using System;
using System.Collections.Generic;
using System.Data.Entity;
using CSharpTest.Model;

namespace CSharpTest.Data.Context
{
    public class CSharpTestDbInitializer : CreateDatabaseIfNotExists<CSharpTestContext>
    {
        protected override void Seed(CSharpTestContext context)
        {
            IList<Order> defaultOrders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    CustomerName = "Raj Edirisinghe",
                    Created = new DateTime(2018, 5, 12),
                    FittingDate = new DateTime(2018, 5, 12),
                    FittingPostcode = "BL47DJ"
                },
                new Order
                {
                    Id = 2,
                    CustomerName = "Gareth Chidgey",
                    Created = new DateTime(2018, 5, 10),
                    FittingDate = new DateTime(2018, 5, 12),
                    FittingPostcode = "SK25BP"
                }
            };
            context.Orders.AddRange(defaultOrders);

            IList<Tyre> defaultTyres = new List<Tyre>
            {
                new Tyre {Id = 1, Description = "Pirelli", BuyPriceExVAT = 250M},
                new Tyre {Id = 2, Description = "Michelin", BuyPriceExVAT = 150M},
                new Tyre {Id = 3, Description = "Continental", BuyPriceExVAT = 270M}
            };
            context.Tyres.AddRange(defaultTyres);

            IEnumerable<OrderItem> defaultOrderItems = new List<OrderItem>()
            {
                new OrderItem(){Id = 1, OrderId = 1, TyreId = 2, Description = "YOKO 185R14C", BuyPriceExVAT = 350, Quantity = 2},
                new OrderItem(){Id = 2, OrderId = 2, TyreId = 2, Description = "MENTOR 185/65R14", BuyPriceExVAT = 450, Quantity = 2},
                new OrderItem(){Id = 3, OrderId = 1, TyreId = 1, Description = "MENTOR 185/65R14", BuyPriceExVAT = 150, Quantity = 2}
            };
            context.OrderItems.AddRange(defaultOrderItems);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}