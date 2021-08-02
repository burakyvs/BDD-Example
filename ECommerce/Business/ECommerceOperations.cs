using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Business
{
    public class ECommerceOperations
    {
        public Basket _basket { get; set; }
        public List<Product> _products { get; set; }
        public ECommerceOperations()
        {
            Basket basket = new Basket();
            _basket = basket;
        }

        public void AddProduct(Product product)
        {
            Product existingProduct = _products.Where(i => i.Name == product.Name).FirstOrDefault();
            if (existingProduct != null)
            {
                existingProduct.Quantity += product.Quantity;
            }
            else
            {
                _products.Add(product);
            }
        }
    }
}
