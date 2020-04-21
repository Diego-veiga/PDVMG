using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Services
{
    public class ProdutoServices
    {

       // private DbContextOptionsBuilder<PDVMGContext> optionsBuilder;
        private PDVMGContext context;




        public ProdutoServices(DbContextOptionsBuilder<PDVMGContext> optionsBuilder)
        {
            
            context = new PDVMGContext(optionsBuilder.Options);
        }


        public Produto PesquisaProduto(int codigoProduto)
        {
            var produto = context.Produtos.SingleOrDefault(p => p.Codigo == codigoProduto);
            return produto;
        }
        public void CadastraProuto(Produto produto)
        {
            context.Add(produto);
            context.SaveChanges();
        }
        public void ExcluirProduto(int cod)
        {
            var produto = context.Produtos.SingleOrDefault(p => p.Codigo == cod);
            produto.Ativo =false;
            context.SaveChanges();
        }
        public void AlteraPreço(Produto produto, double precoatualizado)
        {
            produto.AtualizaPreco(precoatualizado);
            context.SaveChanges();


        }
    }
}
