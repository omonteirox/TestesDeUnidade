using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);

        IEnumerable<Product> GetAll();

        void Save(Product product);

        void Update(Product product);

        void Delete(Guid id);
    }
}