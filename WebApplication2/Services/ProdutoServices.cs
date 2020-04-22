using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Model;

namespace WebApplication2.Services
{
    public class ProdutoServices
    {

        // private DbContextOptionsBuilder<PDVMGContext> optionsBuilder;
        private PDVMGContext context;




        public ProdutoServices(DbContextOptionsBuilder<PDVMGContext> optionsBuilder)
        {

            context = new PDVMGContext(optionsBuilder.Options);
        }


        public List<ProdutoDTO> PesquisaProduto(string NomeProduto)
        {
            context.Database.GetDbConnection();
            var connection = context.Database.GetDbConnection();

            var Produto = new List<ProdutoDTO>();

            using (var comand = connection.CreateCommand())
            {
                connection.Open();

                comand.CommandText = "PesquisaProduto";
                comand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@NomeProduto";
                parameter.SqlDbType = SqlDbType.VarChar;

                parameter.Value = NomeProduto;
                comand.Parameters.Add(parameter);

                using (var DataReader = comand.ExecuteReader())
                {
                    if (DataReader.HasRows)
                    {
                        while (DataReader.Read())
                        {
                            var ProdutoDTO = new ProdutoDTO();
                            ProdutoDTO.Nome = DataReader["NomeProduto"].ToString();
                            ProdutoDTO.PreçoProduto = (double)DataReader["PrecoProduto"];
                            ProdutoDTO.Ativo = (bool)DataReader["Ativo"];
                            Produto.Add(ProdutoDTO);

                        }
                    }
                }

            }

            return Produto;
        }
         public Produto PesquisaProdutoPorCodigo(int codigoProduto)
        {
            return context.Produtos.SingleOrDefault(p => p.Codigo == codigoProduto);

        }
        public void CadastraProuto(Produto produto)
        {
            context.Add(produto);
            context.SaveChanges();
        }
        public void ExcluirProduto(int cod)
        {
            var produto = context.Produtos.SingleOrDefault(p => p.Codigo == cod);
            produto.Ativo = false;
            context.SaveChanges();
        }
        public void AlteraPreço(Produto produto, double precoatualizado)
        {
            produto.AtualizaPreco(precoatualizado);
            context.SaveChanges();


        }
    }
}
