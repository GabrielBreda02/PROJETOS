using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjetoEmpresa.CadProdutos;

namespace ProjetoEmpresa
{
    public class GerenciarProdutos
    {
        public static void Gerenciar(CadProdutos cadProdutos)
        {
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("----- Gerenciar Produtos -----");
                Console.WriteLine("1. Cadastrar Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Buscar Produto");
                Console.WriteLine("4. Alterar Produto");
                Console.WriteLine("5. Excluir Produto");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Entrada inválida! Tente novamente.");
                    Console.ReadLine();
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarProduto(cadProdutos);
                        break;
                    case 2:
                        ListarProdutos(cadProdutos);
                        break;
                    case 3:
                        BuscarProduto(cadProdutos);
                        break;
                    case 4:
                        AlterarProduto(cadProdutos);
                        break;
                    case 5:
                        ExcluirProduto(cadProdutos);
                        break;
                    case 0:
                        Console.WriteLine("Voltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nPressione Enter para continuar...");
                Console.ReadLine();
            } while (opcao != 0);
        }

        private static void CadastrarProduto(CadProdutos cadProdutos)
        {
            Console.Clear();
            Console.WriteLine("----- Cadastrar Produto -----");

            Console.Write("Informe o ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Informe o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o preço do produto: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            var produto = new Produto
            {
                Id = id,
                Nome = nome,
                Preco = preco
            };

            cadProdutos.InserirProduto(produto);
        }

        private static void ListarProdutos(CadProdutos cadProdutos)
        {
            cadProdutos.ListarProdutos();
        }

        private static void BuscarProduto(CadProdutos cadProdutos)
        {
            Console.Clear();
            Console.WriteLine("----- Buscar Produto -----");
            Console.Write("Informe o ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            var produto = cadProdutos.GetProduto(id);
            if (produto != null)
            {
                Console.WriteLine(produto.ToString());
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
        }

        private static void AlterarProduto(CadProdutos cadProdutos)
        {
            Console.Clear();
            Console.WriteLine("----- Alterar Produto -----");
            Console.Write("Informe o ID do produto que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            var produto = cadProdutos.GetProduto(id);
            if (produto != null)
            {
                Console.Write("Informe o novo nome do produto: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Informe o novo preço do produto: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Produto alterado com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
        }

        private static void ExcluirProduto(CadProdutos cadProdutos)
        {
            Console.Clear();
            Console.WriteLine("----- Excluir Produto -----");
            Console.Write("Informe o ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            if (cadProdutos.ExcluirProduto(id))
            {
                Console.WriteLine("Produto excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
        }
    }
}

