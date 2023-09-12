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

        public IEnumerable<Product> Get(IEnumerable<Guid> ids)
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product("Produto 01", 10, true));
            products.Add(new Product("Produto 02", 10, true));
            products.Add(new Product("Produto 03", 10, true));
            products.Add(new Product("Produto 04", 10, false));
            products.Add(new Product("Produto 05", 10, false));

            return products;
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