using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Contracts;

namespace Store.Domain.Commands
{
    internal class CreateOrderItemCommand : Notifiable<Notification>, ICommand
    {
        public CreateOrderItemCommand()
        {
        }

        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product;
        public int Quantity;

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Quantity, 0, "Quantity", "Quantidade Inválida").IsGreaterThan(Product.ToString(), 32, "Product", "Produto Inválido")
                );
        }
    }
}