using MercadinhoGrupoDois.src;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MercadinhoGrupoDois
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> produtos = new();
            List<Carrinho> carrinhos = new();
            string opProd, opMenuInicial, opMenuInicialUpper, opProdUpper, outroProdUpper, outroProd;
            int x = 1;
            double ValorTotalCarrinho = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\n-- Seja Bem Vindo ao Mercadinho Do Grupo 2 --\n");
                Console.WriteLine("-- Escolha uma opção --\n" +
                    "1 - Funcionário\n" +
                    "2 - Consumidor\n");
                Console.Write("Escolha uma opção: ");
                int FuncConsu = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (FuncConsu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("-- Funcionário --");
                        Console.Write("1 - Cadastro de produto\n" +
                                "2 - Listar produto\n" +
                                "3 - Excluir produto\n" +
                                "4 - Voltar ao menu principal\n");
                        Console.Write("Escolha uma opção: ");
                        int CRUD = int.Parse(Console.ReadLine());
                        switch (CRUD)
                        {
                            case 1:
                                Console.Clear();
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n-- Cadastro de produto --");
                                    Console.Write("Nome do produto: ");
                                    string nomeProd = Console.ReadLine();
                                    Console.Write("Valor do produto: ");
                                    double valorProd = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                    produtos.Add(new Produto(nomeProd, valorProd, 0));

                                    Console.WriteLine("\nDeseja cadastrar outro produto? \n" +
                                        "S - Sim\n" +
                                        "N - Não");
                                    Console.Write("Escolha uma opção: ");
                                    opProd = Console.ReadLine();
                                    opProdUpper = opProd.ToUpper();
                                } while (opProdUpper == "S");

                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("-- Listar de produto --");
                                Console.WriteLine("   NOME   |   VALOR  ");
                                foreach (Produto produto in produtos)
                                {
                                    Console.WriteLine($"{produto.Nome} | R${produto.Valor.ToString("F2", CultureInfo.InvariantCulture)}");
                                }
                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("-- Excluir produto --");
                                x = 1;
                                foreach (Produto produto in produtos)
                                {
                                    Console.WriteLine($"{x++} | {produto.Nome}");
                                }

                                Console.Write("Digite o índice do produto: ");
                                int idProd = int.Parse(Console.ReadLine());
                                produtos.RemoveAt(idProd - 1);

                                Console.Write("\n-- Produto apagado com sucesso --\n");
                                x = 1;
                                foreach (Produto produto in produtos)
                                {
                                    Console.WriteLine($"{x++} | {produto.Nome}");
                                }
                                break;

                            default:
                                Console.WriteLine("-- Erro --");
                                break;
                        }
                        break;

                    case 2:
                        Console.Clear();
                        do
                        {
                            Console.WriteLine("-- Consumidor --\n");
                            Console.WriteLine("ID | NOME | VALOR");
                            x = 1;
                            foreach (Produto produto in produtos)
                            {
                                Console.WriteLine($"{x++} | {produto.Nome} | R${produto.Valor.ToString("F2", CultureInfo.InvariantCulture)}");
                            }

                            Console.Write("Coloque ID do produto? ");
                            int selecionaProd = int.Parse(Console.ReadLine());
                            Console.Write("Quantas unidades do produto? ");
                            int unidadeProd = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            carrinhos.Add(new Carrinho(produtos[selecionaProd - 1].Nome, produtos[selecionaProd - 1].Valor, unidadeProd));

                            foreach (Carrinho carrinho in carrinhos)
                            {
                                Console.WriteLine($"{carrinho.Nome} | R${carrinho.Valor.ToString("F2", CultureInfo.InvariantCulture)} | {carrinho.Unidade}");
                            }

                            Console.Write("\nQuer adicionar outro produto? \n" +
                                        "S - Sim\n" +
                                        "N - Não\n");
                            Console.Write("Escolha uma opção: ");
                            outroProd = Console.ReadLine();
                            outroProdUpper = outroProd.ToUpper();
                        } while (outroProdUpper == "S");
                        foreach (Carrinho carrinho in carrinhos)
                        {
                            ValorTotalCarrinho += carrinho.ValorTotal(carrinho.Valor, carrinho.Unidade);
                        }
                        Console.WriteLine($"Valor total: R${ValorTotalCarrinho.ToString("F2", CultureInfo.InvariantCulture)}");

                        break;

                    default:
                        Console.WriteLine("Entre com opção válida!");
                        break;
                }
                Console.Write("\nDeseja voltar no menu inicial \n" +
                                        "S - Sim\n" +
                                        "N - Não\n");
                Console.Write("\nEscolha uma opção: ");
                opMenuInicial = Console.ReadLine();
                opMenuInicialUpper = opMenuInicial.ToUpper();
            } while (opMenuInicialUpper == "S");
            Console.WriteLine("Obrigado e volte sempre!");
        }
    }
}
