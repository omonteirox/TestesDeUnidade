using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            AddNotifications(
                new Contract<Notification>().Requires()
                .IsNotNull(product, "Product", "Produto inválido")
                .IsGreaterThan(quantity, 0, "Quantity", "A quantidade deve ser maior que 0")
                );
            Product = product;
            Price = Product != null ? product.Price : 0;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}