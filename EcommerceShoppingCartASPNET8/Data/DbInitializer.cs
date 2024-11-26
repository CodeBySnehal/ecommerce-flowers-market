using EcommerceShoppingCartASPNET8.Models;
using System;
using System.Linq;

namespace EcommerceShoppingCartASPNET8.Data
{
    public static class DbInitializer
    {
                public static void Initialize(ProductContext context)
                {
                    context.Database.EnsureCreated();

                    if (context.Products.Any())
                    {
                        return;
                    }


                    var products = new Product[]
                    {
                        new Product()
                        {
                            Id = "1",
                            Name = "Aconitum",
                            Photo ="thumb1.jpg",
                            Price = 2.80
                        },
                         new Product()
                        {
                            Id = "2",
                            Name = "Purple Blossom",
                            Photo ="thumb2.jpg",
                            Price = 3.80
                        },
                          new Product()
                        {
                            Id = "3",
                            Name = "Cornflower",
                            Photo ="thumb3.jpg",
                            Price = 3.80
                        },
                           new Product()
                        {
                            Id = "4",
                            Name = "PinkHeart",
                            Photo ="thumb4.jpg",
                            Price = 1.60
                        },
                            new Product()
                        {
                            Id = "5",
                            Name = "African Daisy",
                            Photo ="thumb5.jpg",
                            Price = 2.80
                        },
                             new Product()
                        {
                            Id = "6",
                            Name = "lilies",
                            Photo ="thumb6.jpg",
                            Price = 1.80
                        },
                              new Product()
                        {
                            Id = "7",
                            Name = "Rose",
                            Photo ="thumb7.jpg",
                            Price = 1.80
                        },
                               new Product()
                        {
                            Id = "8",
                            Name = "Baby's Breath",
                            Photo ="thumb8.jpg",
                            Price = 3.60
                        },
                                new Product()
                        {
                            Id = "9",
                            Name = "Cosmos",
                            Photo ="thumb9.jpg",
                            Price = 2.20
                        },
                                 new Product()
                        {
                            Id = "10",
                            Name = "Chrysanthemum",
                            Photo ="thumb10.jpg",
                            Price = 3.60
                        }
                    };
            Console.WriteLine("Initialize executed.");

            context.Products.AddRange(products);  // Add products to context
            context.SaveChanges();

        }
        
    }
}
