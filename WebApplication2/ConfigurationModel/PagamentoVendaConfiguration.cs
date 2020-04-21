using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.ConfigurationModel
{
    public class PagamentoVendaConfiguration : IEntityTypeConfiguration<PagamentoVenda>
    {
        public void Configure(EntityTypeBuilder<PagamentoVenda> builder)
        {
            builder.HasKey(pv => new { pv.IdPagamento, pv.IdVenda });
            builder.Property(pv => pv.DataPagamento).IsRequired();
        }
    }
}
