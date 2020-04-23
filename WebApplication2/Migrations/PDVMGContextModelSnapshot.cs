﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(PDVMGContext))]
    partial class PDVMGContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication2.Model.FormaPagamento", b =>
                {
                    b.Property<int>("IdPagamento")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("NomePagamento")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TipoPagamento");

                    b.HasKey("IdPagamento");

                    b.ToTable("FormaPagamentos");
                });

            modelBuilder.Entity("WebApplication2.Model.ItemVenda", b =>
                {
                    b.Property<int>("VendaIdVenda");

                    b.Property<int>("ProdutoCodigo");

                    b.Property<int>("NumeroItem");

                    b.Property<double>("PrecoItem");

                    b.Property<int>("Quantidade");

                    b.HasKey("VendaIdVenda", "ProdutoCodigo");

                    b.HasIndex("ProdutoCodigo");

                    b.ToTable("ItemVenda");
                });

            modelBuilder.Entity("WebApplication2.Model.PagamentoVenda", b =>
                {
                    b.Property<int>("IdPagamento");

                    b.Property<int>("IdVenda");

                    b.Property<DateTime>("DataPagamento");

                    b.Property<double>("Valor");

                    b.HasKey("IdPagamento", "IdVenda");

                    b.HasIndex("IdVenda");

                    b.ToTable("PagamentoVendas");
                });

            modelBuilder.Entity("WebApplication2.Model.Produto", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<double>("PrecoProduto");

                    b.HasKey("Codigo");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("WebApplication2.Model.Venda", b =>
                {
                    b.Property<int>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataVenda");

                    b.Property<int>("StatusVenda");

                    b.Property<double>("Troco");

                    b.Property<double>("ValorTotalVenda");

                    b.HasKey("IdVenda");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("WebApplication2.Model.ItemVenda", b =>
                {
                    b.HasOne("WebApplication2.Model.Produto", "Produto")
                        .WithMany("ItemVendas")
                        .HasForeignKey("ProdutoCodigo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication2.Model.Venda", "Venda")
                        .WithMany("Items")
                        .HasForeignKey("VendaIdVenda")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication2.Model.PagamentoVenda", b =>
                {
                    b.HasOne("WebApplication2.Model.FormaPagamento", "FormaPagamento")
                        .WithMany("PagamentoVendas")
                        .HasForeignKey("IdPagamento")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication2.Model.Venda", "Vendas")
                        .WithMany("PagamentoVenda")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
