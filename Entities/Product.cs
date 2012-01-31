using System.Collections.Generic;

namespace DegradingLoad.Entities
{
    public class Product
    {
        public int productId { get; set; }
        public string imageUrl { get; set; }
        public string title { get; set; }
        public double price { get; set; }
    }

    public static class DemoProduct
    {
        public static List<Product> GetDemoProducts()
        {
            return new List<Product>{ 
                new Product { 
                    productId = 123, 
                    imageUrl = "http://ecx.images-amazon.com/images/I/51FTPACE1HL._SL500_SL135_.jpg", 
                    title = "Transmetropolit​an: Dirge", 
                    price = 55.00 
                },
                new Product { 
                    productId = 456, 
                    imageUrl = "http://ecx.images-amazon.com/images/I/51YCMS0YC3L._SL500_SL135_.jpg", 
                    title = "The Death of Clark Kent", 
                    price = 38.00 
                },
                new Product { 
                    productId = 789, 
                    imageUrl = "http://ecx.images-amazon.com/images/I/5136QXN0BEL._SL500_SS135_.jpg", 
                    title = "Transmetropolitan: Spider's Thrash", 
                    price = 36.00 
                },
                new Product { 
                    productId = 101112, 
                    imageUrl = "http://ecx.images-amazon.com/images/I/31gqh3830kL._SL500_SS135_.jpg", 
                    title = "Countdown to Adventure", 
                    price = 38.00 
                }
            };
        }
    }
}
