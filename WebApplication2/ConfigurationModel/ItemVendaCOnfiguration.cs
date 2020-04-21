using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.ConfigurationModel
{
    public class ItemVendaConfiguration : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.HasKey(vi => new { vi.VendaIdVenda, vi.ProdutoCodigo });
            builder.Property(vi => vi.Quantidade).IsRequired();
            builder.Property(vi => vi.NumeroItem).IsRequired();
            builder.Property(vi => vi.PrecoItem).IsRequired();










            ;

        }
    }
}
