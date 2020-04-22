using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Enum;
using WebApplication2.Model;

namespace WebApplication2.Services
{
    public class VendaService
    {
        PDVMGContext contextVenda;



        public VendaService(DbContextOptionsBuilder<PDVMGContext> optionsBuilder)
        {
            contextVenda = new PDVMGContext(optionsBuilder.Options);

        }

        public void GravaVenda(Venda venda)
        {
            contextVenda.Add(venda);
            contextVenda.SaveChanges();
        }
        public Venda VerificaVendaCancelada(int idVenda)
        {
            var prod = contextVenda.Vendas.FirstOrDefault(v => v.IdVenda == idVenda && v.StatusVenda != StatusVenda.Cancelada);
            return prod;
        }
        public void CancelaVenda(Venda v)
        {
            v.StatusVenda = Enum.StatusVenda.Cancelada;
            contextVenda.SaveChanges();
            Console.WriteLine("Venda cancelada com sucesso");
        }
        public VendaDTO PesquisaVenda(int id)
        {

            var Venda = new VendaDTO();
            try
            {
                contextVenda.Database.GetDbConnection();
                var connection = contextVenda.Database.GetDbConnection();



                using (var comand = connection.CreateCommand())
                {
                    connection.Open();

                    comand.CommandText = "PesquisaVenda";
                    comand.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@id";
                    parameter.SqlDbType = SqlDbType.Int;

                    parameter.Value = id;
                    comand.Parameters.Add(parameter);

                    using (var DataReader = comand.ExecuteReader())
                    {
                        if (DataReader.HasRows)
                        {
                            while (DataReader.Read())
                            {
                                Venda.IdVenda =(int) DataReader["id"];
                                Venda.ValorTotal = (double)DataReader["ValorTotal"];
                                Venda.DataVenda = (DateTime)DataReader["DataVenda"];
                                Venda.StatusVenda = DataReader["StatusVenda"].ToString();
                                /*Venda. = DataReader["NomeProduto"].ToString();
                                ProdutoDTO.PreçoProduto = (double)DataReader["PrecoProduto"];
                                ProdutoDTO.Ativo = (bool)DataReader["Ativo"];
                                Produto.Add(ProdutoDTO);*/

                            }
                        }
                    }

                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);


            }
            return Venda;
        }
    }
}
