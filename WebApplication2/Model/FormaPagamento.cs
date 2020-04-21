using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Enum;
using WebApplication2.Exceptions;

namespace WebApplication2.Model
{
    public class FormaPagamento
    {
        public int IdPagamento { get; set; }
        public string NomePagamento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public virtual ICollection<PagamentoVenda> PagamentoVendas { get; set; }

        public FormaPagamento()
        {
                    
        }
        public FormaPagamento(string nome, TipoPagamento tipoPagamento)
        {
            if (nome.Length == 1)
            {
                throw new ExceptionFormasDepagamento("O nome da forma de pagamento não conter apenas um caratere");
            }else if (string.IsNullOrEmpty(nome))
            {
                throw new ExceptionFormasDepagamento("O nome da forma de pagamento não pode ser nula");
            }else if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ExceptionFormasDepagamento("O nome da forma de pagamento não pode conter espço");
            }
            else
            {
                NomePagamento = nome.ToLower();
            }
            NomePagamento = nome;
            DataCadastro = DateTime.Now;
            TipoPagamento = tipoPagamento;
            Ativo = true;


        }
    }
}
