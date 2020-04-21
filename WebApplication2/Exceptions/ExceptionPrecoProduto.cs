using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Exceptions
{
    public class ExceptionPrecoProduto :ApplicationException
    {
        public ExceptionPrecoProduto(string mensagem ):base (mensagem)
        {

        }
    }
}
