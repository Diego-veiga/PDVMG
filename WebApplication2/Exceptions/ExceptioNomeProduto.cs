using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Exceptions
{
    public class ExceptioNomeProduto : ApplicationException
    {
        public ExceptioNomeProduto(string mensagem):base (mensagem)
        {

        }
    }
}
