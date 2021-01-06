using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class ProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products =  new List<Product>(new[] { new Product { Id = 1, Name = "Pants" } });
        }

        public Product[] Get() 
        {
            return _products.ToArray();
        }

        public Product Add(Product value)
        {
            _products.Add(value);

            value.Id = _products.Count;

            return value;
        }

        public void Delete(int id)
        {
            var match = _products.FirstOrDefault(model => model.Id == id);

            if (match != null)
            {
                _products.Remove(match);
            }
        }

        public object Get(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}