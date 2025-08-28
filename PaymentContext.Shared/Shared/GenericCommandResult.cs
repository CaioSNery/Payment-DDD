using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Shared
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; }
        public string Message { get; }
        public object Data { get; }
    }
}