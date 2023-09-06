using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount(decimal amount, DateTime expireDate)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerThan(expireDate, DateTime.Now, "Discount.Date", "A data deve ser igual ou superior que a data de hoje ")
                );
            Amount = amount;
            ExpireDate = expireDate;
        }

        public decimal Amount { get; private set; }
        public DateTime ExpireDate { get; private set; }

        public bool IsValidDiscount() => DateTime.Compare(DateTime.Now, ExpireDate) < 0;

        public decimal Value()
        {
            if (IsValidDiscount())
                return Amount;
            else
                return 0;
        }
    }
}