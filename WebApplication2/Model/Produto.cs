using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Exceptions;

namespace WebApplication2.Model
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string NomeProduto{ get;private  set; }
        public double  PrecoProduto { get; set; }
        public  virtual ICollection<ItemVenda> ItemVendas { get; set; }
        public bool Ativo { get; set; }

        public Produto()
        {

        }
        public Produto(string nome,double preco)
        {
            if (nome.Length == 1)
            {
                throw new ExceptioNomeProduto("O nome do produto tem apenas uma letra");
            }else if (string.IsNullOrEmpty(nome) == true)
            {
                throw new ExceptioNomeProduto("O nome do produto não pode ser vazio");
            }else if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ExceptioNomeProduto("O nome do produto não pode conter apneas espaços");
            }
            else
            {
                NomeProduto = nome;
            }
            if (preco == 0)
            {
                throw new ExceptionPrecoProduto("Um produto não pode ter preço 0");
            }else if (preco == null)
            {
               throw new ExceptionPrecoProduto("O preço do produto não pode ser braco");

            }
            else
            {
                PrecoProduto = preco;
            }
            Ativo = true;


        }

        public void AtualizaPreco(double preco)
        {
            PrecoProduto = preco;
        }

    }
     
    
   
}
