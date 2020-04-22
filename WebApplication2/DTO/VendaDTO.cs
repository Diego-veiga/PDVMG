using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DTO
{
    public class VendaDTO
    {
        public int IdVenda { get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }
        public string StatusVenda { get; set; }
    }
}
