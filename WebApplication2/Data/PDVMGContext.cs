using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.ConfigurationModel;
using WebApplication2.Model;

namespace WebApplication2.Data
{
    public class PDVMGContext : DbContext
    {
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<PagamentoVenda> PagamentoVendas { get; set; }

        public PDVMGContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VendaConfiguration());
            modelBuilder.ApplyConfiguration(new ItemVendaConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration ());
            modelBuilder.ApplyConfiguration(new PagamentoVendaConfiguration());
        
            base.OnModelCreating(modelBuilder);
        }
    }
}


