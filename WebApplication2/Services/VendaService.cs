using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Enum;
using WebApplication2.Model;

namespace WebApplication2.Services
{
    public class VendaService
    {
        PDVMGContext contextVenda;

       

        public VendaService(DbContextOptionsBuilder<PDVMGContext> optionsBuilder)
        {
             contextVenda = new PDVMGContext(optionsBuilder.Options);

        }

        public void GravaVenda(Venda venda)
        {
            contextVenda.Add(venda);
            contextVenda.SaveChanges();
        }
        public Venda VerificaVendaCancelada(int idVenda)
        {
            var prod= contextVenda.Vendas.FirstOrDefault(v => v.IdVenda == idVenda && v.StatusVenda!=StatusVenda.Cancelada);
            return prod;
        }
        public void CancelaVenda(Venda v)
        {
            v.StatusVenda = Enum.StatusVenda.Cancelada;
            contextVenda.SaveChanges();
            Console.WriteLine("Venda cancelada com sucesso");
        }
    }
}
