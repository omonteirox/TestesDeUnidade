using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}