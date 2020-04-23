using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Enum;

namespace WebApplication2.Model
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public double ValorTotalVenda { get; private set; }
        public virtual ICollection<ItemVenda> Items { get; set; } = new List<ItemVenda>();
        public StatusVenda StatusVenda { get; set; }
        public virtual ICollection<PagamentoVenda> PagamentoVenda { get; set; } = new List<PagamentoVenda>();
        public double Troco { get; set; }

        public Venda()
        {

        }
        public Venda(StatusVenda statusVenda)
        {
            StatusVenda = statusVenda;
            DataVenda = DateTime.Now;
        }

        public void AdicionaItem(ItemVenda item)
        {
            if (Items.Count >0)
            {
                foreach (var i in Items.ToList())
                {
                    if (item.ProdutoCodigo == i.ProdutoCodigo)
                    {
                        i.Quantidade = i.Quantidade+ item.Quantidade;
                    }
                    else
                    {
                        Items.Add(item);

                    }
                }
            }
            else
            {
                Items.Add(item);

            }
            
        }
        public double ValorTotal()
        {
            
            double ValorItem=0;
            foreach (var item in Items)
            {
                ValorItem =+ item.PrecoItem * item.Quantidade;
                ValorTotalVenda = ValorTotalVenda + ValorItem;
            }

            return ValorTotalVenda;


        }
        public void AdicionaFormaPagamento(PagamentoVenda f)
        {
            PagamentoVenda.Add(f);
        }
    }
}
