using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Entities
{
    public class Basket
    {
        // List<Product> Products { get; set; }
        private Dictionary<Product, int> Products { get; set; }
        public int TotalPrice { get; set; }

        public Basket()
        {
            Products = new Dictionary<Product, int>();
            TotalPrice = 0;
        }

        public Basket(Dictionary<Product, int> products)
        {
            Products = products;
        }

        public void AddToBasket(Product product, int count)
        {
            var inBasketProduct = Products.Where(i => i.Key.Name == product.Name).FirstOrDefault();
            if (inBasketProduct.Key != null)
                Products.Add(product, inBasketProduct.Value + count);
            else
                Products.Add(product, count);

            TotalPrice += product.Price * count;
        }

        public void RemoveBasket(Product product)
        {
            Products.Remove(product);
        }

        public int CountBasket()
        {
            return Products.Count;
        }

        public void ClearBasket()
        {
            Products.Clear();
        }

        public bool FindInBasket(Product product)
        {
            return Products.Any(i => i.Key.Name == product.Name);
        }
    }
}
