using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoGrupoDois.src
{
    class Carrinho : Produto
    {
        public Carrinho(string nome, double valor, int unidade) : base(nome, valor, unidade)
        {
        }

        public virtual double ValorTotal(double valor, int unidade)
        {
            return valor * unidade;
        }
    }
}
