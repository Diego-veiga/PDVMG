using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
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
    }
}
