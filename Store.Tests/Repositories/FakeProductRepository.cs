using Store.Domain.Entities;
using Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public void Delete(Guid id)
        {
            return;
        }

        public Product Get(Guid id)
        {
            if (id == Guid.Parse("c0a0fd0e-0e5b-4e5a-8b6d-2f6a9a4b9e1a"))
                return new Product("Produto 01", 10, true);
            return null;
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> _products = new();
            _products.Add(new Product("Produto 01", 10, true));
            _products.Add(new Product("Produto 02", 10, true));
            _products.Add(new Product("Produto 03", 10, true));
            _products.Add(new Product("Produto 04", 10, true));
            _products.Add(new Product("Produto 05", 10, true));
            _products.Add(new Product("Produto 06", 10, false));
            _products.Add(new Product("Produto 07", 10, false));
            IEnumerable<Product> products = _products;

            return products;
        }

        public void Save(Product product)
        {
            return;
        }

        public void Update(Product product)
        {
            return;
        }
    }
}