using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get(IEnumerable<Guid> ids);

        IEnumerable<Product> GetAll();

        void Save(Product product);

        void Update(Product product);

        void Delete(Guid id);
    }
}