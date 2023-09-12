using Store.Domain.Queries;
using Store.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {
        private FakeProductRepository _repository = new FakeProductRepository();

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_ativos_deve_retornar_5()
        {
            var products = _repository.GetAll();
            var result = products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
        {
            var products = _repository.GetAll();
            var result = products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
            Assert.AreEqual(2, result.Count());
        }
    }
}