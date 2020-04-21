using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Exceptions
{
    public class ExceptionFormasDepagamento :ApplicationException
    {
        public ExceptionFormasDepagamento(string Message): base(Message)
        {

        }
    }
}
