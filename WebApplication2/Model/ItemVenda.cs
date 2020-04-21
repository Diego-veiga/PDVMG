using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class ItemVenda
    {
        public int Quantidade { get; set; }
        public double PrecoItem { get; set; }
        public int NumeroItem { get; set; }
            

        public int VendaIdVenda { get; set; }
        public virtual Venda Venda { get; set; }

        public int ProdutoCodigo { get; set; }
        public virtual Produto Produto { get; set; }

        public ItemVenda()
        {

        }

        public ItemVenda(int quantidade, Produto produto, Venda venda)
        {
            Quantidade = quantidade;
            ProdutoCodigo = produto.Codigo;
            PrecoItem = RetornaPrecoProduto(produto);
            NumeroItem = RetornaNumeroItemVenda(venda);
            Venda = venda;

        }
        public double RetornaPrecoProduto(Produto produto)
        {
            return produto.PrecoProduto;
        }
        public int RetornaNumeroItemVenda(Venda venda)
        {
            int NumeroItem = venda.Items.Count();

            return NumeroItem += 1;
        }


    }
}
