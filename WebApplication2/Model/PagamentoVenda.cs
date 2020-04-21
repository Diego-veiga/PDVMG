using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class PagamentoVenda
    {
        public int IdVenda { get; set; }
        public virtual Venda Venda { get; set; }

        public int IdPagamento { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        public DateTime DataPagamento { get; set; }
    }
}
