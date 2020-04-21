using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.ConfigurationModel
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(p => p.IdPagamento);
            builder.Property(p => p.NomePagamento).IsRequired().HasMaxLength(50);
            builder.Property(p => p.TipoPagamento).IsRequired();
            builder.Property(p => p.DataCadastro).IsRequired();
        
        }
    }
}
