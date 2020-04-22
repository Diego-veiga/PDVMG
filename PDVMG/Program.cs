using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using WebApplication2.Data;
using WebApplication2.Model;
using WebApplication2.Services;
using System.Globalization;
using WebApplication2.Enum;
using WebApplication2.Exceptions;
using Microsoft.Extensions.Options;
using WebApplication2.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace PDVMG
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PDVMGContext>();


            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server = localhost; Database = PDVMG; Trusted_Connection = True; MultipleActiveResultSets = true;", m => m.MigrationsAssembly("Switch.Infra.Data").MaxBatchSize(1000));
            optionsBuilder.EnableSensitiveDataLogging();
            int? opcaoGeral = null;
            while (opcaoGeral != 0)
            {
                try
                {
                    Console.WriteLine("Entre com a opção que deseja:\n"
                                    + "1 - Operações com produto \n"
                                    + "2 - Operações com venda \n"
                                    + "3 - Formas de Pagamento");
                    opcaoGeral = int.Parse(Console.ReadLine());




                    switch (opcaoGeral)
                    {
                        case 1:

                            int? opcaoProduto = null;
                            while (opcaoProduto != 0)
                            {
                                try
                                {
                                    Console.WriteLine("Entre com a opção que deseja: \n"
                                                    + "1 - Cadastro de produtos \n"
                                                    + "2 - Procura Produto \n"
                                                    + "3 - Excluir Produtos \n"
                                                    + "4 - Ajustar preço do produto");
                                    opcaoProduto = int.Parse(Console.ReadLine());




                                    switch (opcaoProduto)
                                    {
                                        case 1:
                                            Produto produtoCadastro;
                                            string nome = null;
                                            double preco = 0;
                                            try
                                            {
                                                Console.WriteLine("Entre com o nome do produto");
                                                nome = Console.ReadLine();
                                                Console.WriteLine("Entre com o preço do produto ");
                                                preco = double.Parse(Console.ReadLine());
                                                produtoCadastro = new Produto(nome, preco);
                                                ProdutoServices produtosservices = new ProdutoServices(optionsBuilder);
                                                produtosservices.CadastraProuto(produtoCadastro);
                                                Console.WriteLine("Produto cadastrado com sucesso");


                                            }
                                            catch (FormatException e)
                                            {
                                                Console.WriteLine("Algum campo foi digitado incorretamente");
                                            }
                                            catch (ExceptioNomeProduto e)
                                            {
                                                Console.WriteLine(e.Message);
                                            }
                                            catch (ExceptionPrecoProduto e)
                                            {
                                                Console.WriteLine(e.Message);
                                            }
                                            catch (DbException e)
                                            {
                                                Console.WriteLine(e.Message);


                                            }
                                            break;

                                        case 2:

                                            try
                                            {

                                                Console.WriteLine("Entre com o nome do produto que seja pesquisar");
                                                string NomeProdutoPesquisa = Console.ReadLine();
                                                ProdutoServices p = new ProdutoServices(optionsBuilder);
                                               List<ProdutoDTO> produtoDTO = p.PesquisaProduto(NomeProdutoPesquisa);



                                                foreach (var i in produtoDTO)
                                                    {
                                                        Console.WriteLine("Nome Produto: " + i.Nome + "\n"+
                                                                         "Preço Produto: " + i.PreçoProduto + "\n" +
                                                                          "Ativo: " + i.Ativo);
                                                    }



                                                }
                                            
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);

                                            }

                                            break;
                                        case 3:
                                            try
                                            {
                                                Console.WriteLine("Entre com o código de produto que deseja excluir ");
                                                int produtoexcluir = int.Parse(Console.ReadLine());
                                                ProdutoServices pe = new ProdutoServices(optionsBuilder);
                                                pe.ExcluirProduto(produtoexcluir);
                                                Console.WriteLine("Produto Desativado com suceso");
                                            }
                                            catch (FormatException e)
                                            {
                                                Console.WriteLine("Você digitou uma letra no lugar do numero");
                                            }
                                            catch (DbException e)
                                            {
                                                Console.WriteLine("Algo de errado deu no banco de dados");
                                            }

                                            break;
                                        case 4:
                                            try
                                            {
                                                Console.WriteLine("entre com o código do produto que deseja alterar:");
                                                int codigoPro = int.Parse(Console.ReadLine());
                                                ProdutoServices prod = new ProdutoServices(optionsBuilder);
                                                var produt = prod.PesquisaProdutoPorCodigo(codigoPro);
                                                if (produt == null)
                                                {
                                                    Console.WriteLine("O codigo de produto que você digitou não existe");

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Produto Selecionado:   " + produt.NomeProduto +
                                                                      "   Preço produto R$:    " + produt.PrecoProduto);
                                                    Console.WriteLine("Entre com o preço do produto:");
                                                    double precoAtualizado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                                    prod.AlteraPreço(produt, precoAtualizado);
                                                }
                                                Console.WriteLine("Entre com a opção que deseja: \n"
                                               + "1 - Cadastro de produtos \n"
                                               + "2 - Lista de produtos \n"
                                               + "3 - Esxcluir Produtos \n"
                                               + "4 - ajustar preço do produto");
                                                opcaoProduto = int.Parse(Console.ReadLine());
                                            }
                                            catch (FormatException e)
                                            {
                                                Console.WriteLine("Você digitou algum caractere invalido");
                                            }
                                            catch (DbException e)
                                            {
                                                Console.WriteLine("Algo de errado ocorreu no banco de dados");
                                            }
                                            break;
                                    }
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Por favor escolha o numero da opção desejada ");
                                }

                            }



                            break;

                        case 2:
                            int? opcaoVenda = null;
                            while (opcaoVenda != 0)
                            {
                                try
                                {
                                    Console.WriteLine("1 - Realizar Venda \n"
                                                  + "2 - Cancelar Venda \n"
                                                  + "3 - Consultar Venda \n");
                                    opcaoVenda = int.Parse(Console.ReadLine());



                                    switch (opcaoVenda)
                                    {
                                        case 1:
                                            int FinalizaVenda = 1;
                                            Venda venda = new Venda(StatusVenda.Iniciada);
                                            while (FinalizaVenda != 0)
                                            {

                                                Console.WriteLine("Entre com o codigo do produto");
                                                int PVenda = int.Parse(Console.ReadLine());
                                                ProdutoServices ProdutoVenda = new ProdutoServices(optionsBuilder);
                                                ItemVendaService itv = new ItemVendaService(optionsBuilder);

                                                var p = ProdutoVenda.PesquisaProdutoPorCodigo(PVenda);
                                                if (p == null)
                                                {
                                                    Console.WriteLine("Produto digitado não existe");

                                                }
                                                else
                                                {

                                                    Console.WriteLine("Produto Selecionado:  " + p.NomeProduto +
                                                                      "  Preço R$: " + p.PrecoProduto);
                                                    Console.WriteLine("Entre com a quantidade");
                                                    int quantidadeVenda = int.Parse(Console.ReadLine());
                                                    ItemVenda iv = new ItemVenda(quantidadeVenda, p, venda);
                                                    venda.AdicionaItem(iv);
                                                }
                                                Console.WriteLine("Digite 0 para finalziar a venda ou 1 para continuar");
                                                FinalizaVenda = int.Parse(Console.ReadLine());


                                            }

                                            venda.ValorTotal();
                                            venda.StatusVenda = StatusVenda.Finalizada;

                                            VendaService v = new VendaService(optionsBuilder);
                                            v.GravaVenda(venda);
                                            Console.WriteLine("Venda realizada com sucesso");


                                            break;
                                    }
                                }

                                catch (FormatException e)
                                {
                                    Console.WriteLine("Opção incorreta");
                                }
                                catch (DbException e)
                                {
                                    Console.WriteLine("Algo de errado ocorreu no banco de dados");
                                }


                            }
                            break;
                        case 3:
                            int? opcaoPagamento = null;
                            FormaPagamento FormaPagamento = null;
                            try
                            {
                                Console.WriteLine("1 - Cadastrar Forma de pagamento\n"
                                                 + "2 - Excluir Formas de pagamento \n"
                                                 + "3 - Atualizar forma de pagamento");
                                opcaoPagamento = int.Parse(Console.ReadLine());

                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Valor Digitado incorretamente");
                            }
                            while (opcaoPagamento != 0)
                            {


                                switch (opcaoPagamento)
                                {
                                    case 1:
                                        string NomeFormaPagamento;
                                        var opcaoTipo = 0;
                                        FormasPagamentoService fgs = new FormasPagamentoService(optionsBuilder);
                                        try
                                        {
                                            Console.WriteLine("Entre com o nome da forma de pagameno");
                                            NomeFormaPagamento = Console.ReadLine();
                                            Console.WriteLine("Escolha o tipo de pagamento: \n"
                                                             + "1 - Dinheiro \n"
                                                             + "2 - Credito \n"
                                                             + "3 - Debito");
                                            opcaoTipo = int.Parse(Console.ReadLine());

                                            if (opcaoTipo == 1)
                                            {
                                                FormaPagamento = new FormaPagamento(NomeFormaPagamento, TipoPagamento.Dinheiro);

                                            }
                                            else if (opcaoTipo == 2)
                                            {

                                                FormaPagamento = new FormaPagamento(NomeFormaPagamento, TipoPagamento.CartãoCrédito);

                                            }
                                            else if (opcaoTipo == 3)
                                            {
                                                FormaPagamento = new FormaPagamento(NomeFormaPagamento, TipoPagamento.CartãoDebito);
                                            }
                                            fgs.InserirPagamento(FormaPagamento);



                                        }
                                        catch (DbException e)
                                        {
                                            Console.WriteLine("Algo de errado ocorreu no banco de dados");
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }



                                        break;
                                    case 2:
                                        try
                                        {
                                            Console.WriteLine("Entre com a forma de pagamento ");
                                            string NomeExcluir;
                                            NomeExcluir = Console.ReadLine();
                                            FormasPagamentoService formasPagamentoServiceExclui = new FormasPagamentoService(optionsBuilder);
                                            FormaPagamento formaExclui = formasPagamentoServiceExclui.ProcuraForma(NomeExcluir);
                                            if (formaExclui == null)
                                            {
                                                Console.WriteLine("Forma de pagamento não cadastrada");
                                            }
                                            else
                                            {
                                                formasPagamentoServiceExclui.EscluirFormaPagamento(formaExclui);


                                            }

                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;
                                    case 3:
                                        Console.WriteLine("Entre com o nome da forma de pagamento ");
                                        string nome = Console.ReadLine();
                                        FormasPagamentoService formasPagamentoService = new FormasPagamentoService(optionsBuilder);
                                        FormaPagamento forma = formasPagamentoService.ProcuraForma(nome);
                                        if (forma == null)
                                        {
                                            Console.WriteLine("A forma de pagamento não existe");
                                        }
                                        else
                                        {

                                        }

                                        break;
                                }
                                Console.WriteLine("1 - Cadastrar Forma de pagamento\n"
                                                + "2 - Excluir Formas de pagamento \n"
                                                + "3 - Atualizar forma de pagamento");
                                opcaoPagamento = int.Parse(Console.ReadLine());

                            }
                            break;






                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Por favor digite o numero da opção");

                }

            }


            Console.WriteLine("Foi um prazer atender você");

            Console.ReadLine();

        }




    }
}

