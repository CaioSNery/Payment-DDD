using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentContext.Shared.Commands
{
    public interface ICommandResult
    {
        bool Sucess { get; }
        string Message { get; }
        object Data { get; }
    }
}