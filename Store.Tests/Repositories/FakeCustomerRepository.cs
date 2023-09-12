using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(Guid id)
        {
            if (id == Guid.Parse("1b1d7e4f-9f1f-4a1d-9a5f-6d8d6b5fe0b1"))
                return new Customer("Bruce", "Wayne");
            return null;
        }
    }
}