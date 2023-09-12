using Store.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        public ICommandResult Handle(T command);
    }
}