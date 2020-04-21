using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Services
{
    public class FormasPagamentoService
    {
        PDVMGContext contextPagamento;



        public FormasPagamentoService(DbContextOptionsBuilder<PDVMGContext> optionsBuilder)
        {
            contextPagamento = new PDVMGContext(optionsBuilder.Options);

        }

        public void InserirPagamento(FormaPagamento formaPagamento)
        {
            contextPagamento.Add(formaPagamento);
            contextPagamento.SaveChanges();
            Console.WriteLine("Forma de pagamento Cadastrada com sucesso");

        }
        public FormaPagamento ProcuraForma(string NomePagamento)
        {
           return contextPagamento.FormaPagamentos.FirstOrDefault(pg => pg.NomePagamento == NomePagamento);
        }
        public void EscluirFormaPagamento( FormaPagamento forma)
        {
            forma.Ativo = false;
            contextPagamento.SaveChanges();
            Console.WriteLine("Forma de pagamento Excluída com sucesso");
        }
    }
}
