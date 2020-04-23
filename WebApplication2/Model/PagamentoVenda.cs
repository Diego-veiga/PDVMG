using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class PagamentoVenda
    {
        public int IdVenda { get; set; }
        public virtual Venda Vendas { get; set; }

        public int IdPagamento { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }

        public PagamentoVenda()
        {
                  
        }
        public PagamentoVenda(Venda v, FormaPagamento f, double valor)
        {
            IdPagamento = f.IdPagamento;
            Vendas = v;
            Valor = valor;
            DataPagamento = DateTime.Now;

        }
    }
}
