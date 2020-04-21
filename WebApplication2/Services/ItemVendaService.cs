using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2.Services
{
    public class ItemVendaService
    {
        PDVMGContext context;

        public ItemVendaService(DbContextOptionsBuilder<PDVMGContext> optionsBuilder)
        {
            context= new PDVMGContext(optionsBuilder.Options);
        }
    }
}
