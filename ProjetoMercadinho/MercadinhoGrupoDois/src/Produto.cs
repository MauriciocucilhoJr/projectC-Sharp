using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoGrupoDois.src
{
    class Produto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Unidade { get; set; }

        public Produto()
        {
        }
        public Produto(string nome, double valor, int unidade)
        {
            Nome = nome;
            Valor = valor;
            Unidade = unidade;
        }




    }
}
