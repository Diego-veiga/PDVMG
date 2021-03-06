﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(PDVMGContext))]
    [Migration("20200401223923_adicionandoitemvenda")]
    partial class adicionandoitemvenda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication2.Model.ItemVenda", b =>
                {
                    b.Property<int>("IdItemVenda")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumeroItem");

                    b.Property<double>("PrecoItem");

                    b.Property<int>("Quantidade");

                    b.Property<int>("VendaIdVenda");

                    b.HasKey("IdItemVenda");

                    b.HasIndex("VendaIdVenda");

                    b.ToTable("ItemVenda");
                });

            modelBuilder.Entity("WebApplication2.Model.Venda", b =>
                {
                    b.Property<int>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataVenda");

                    b.Property<double>("ValorTotalVenda");

                    b.HasKey("IdVenda");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("WebApplication2.Model.ItemVenda", b =>
                {
                    b.HasOne("WebApplication2.Model.Venda", "Venda")
                        .WithMany("Items")
                        .HasForeignKey("VendaIdVenda")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
