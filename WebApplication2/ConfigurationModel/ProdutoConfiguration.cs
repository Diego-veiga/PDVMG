using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.ConfigurationModel
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.NomeProduto).HasMaxLength(60).IsRequired();
            builder.Property(p => p.PrecoProduto).IsRequired();
            builder.Property(p => p.Ativo).IsRequired();
            
        }
    }
}
