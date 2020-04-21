using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.ConfigurationModel
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(u => u.IdVenda);
            builder.Property(u => u.DataVenda).IsRequired();
            builder.Property(u => u.ValorTotalVenda).IsRequired();
            builder.HasMany(v => v.Items).WithOne(it => it.Venda);
            builder.Property(v => v.StatusVenda).IsRequired();


  

        }
    }
}
