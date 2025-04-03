using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmpresa
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Instâncias das classes para manipulação
            CadProdutos cadProdutos = new CadProdutos();
            CadClientes cadClientes = new CadClientes();
            Estoque estoque = new Estoque();
            CadVendas cadVendas = new CadVendas();
            

            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("----- Menu Principal -----");
                Console.WriteLine("1. Gerenciar Produtos");
                Console.WriteLine("2. Gerenciar Clientes");
                Console.WriteLine("3. Gerenciar Estoque");
                Console.WriteLine("4. Registrar Venda");
                Console.WriteLine("5. Listar Vendas Realizadas");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                // Validação da entrada
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Entrada inválida! Pressione Enter para tentar novamente.");
                    Console.ReadLine();
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        GerenciarProdutos(cadProdutos); // Chamando a função para gerenciar produtos
                        break;
                    case 2:
                        GerenciarClientes(cadClientes); // Chamando a função para gerenciar clientes
                        break;
                    case 3:
                        GerenciarEstoque(estoque, cadProdutos); // Estoque interagindo com os produtos
                        break;
                    case 4:
                        RegistrarVenda(cadClientes, estoque, cadVendas); // Registrando uma venda
                        break;
                    case 5:
                        ListarVendas(cadVendas); // Listando vendas realizadas
                        break;
                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione Enter para continuar...");
                Console.ReadLine();
            } while (opcao != 0);
        }

        // Métodos estáticos de gerenciamento
        static void GerenciarProdutos(CadProdutos cadProdutos)
        {
            // Chamar o método de gerenciamento de produtos
            Console.WriteLine("Gerenciamento de Produtos ainda não implementado.");
        }

        static void GerenciarClientes(CadClientes cadCliente)
        {
            // Chamar o método de gerenciamento de clientes
            Console.WriteLine("Gerenciamento de Clientes ainda não implementado.");
        }

        static void GerenciarEstoque(Estoque estoque, CadProdutos cadProdutos)
        {
            // Chamar o método de gerenciamento de estoque
            Console.WriteLine("Gerenciamento de Estoque ainda não implementado.");
        }

        static void RegistrarVenda(CadClientes cadCliente, Estoque estoque, CadVendas cadastroVendas)
        {
            // Chamar o método de registro de vendas
            Console.WriteLine("Registro de Venda ainda não implementado.");
        }

        static void ListarVendas(CadVendas cadastroVendas)
        {
            // Chamar o método de listagem de vendas
            Console.WriteLine("Listagem de Vendas ainda não implementada.");
        }

        static void GerenciarEstoques(Estoque estoque, CadProdutos cadProdutos)
        {
            Console.Clear();
            Console.WriteLine("----- Gerenciar Estoque -----");
            Console.WriteLine("1. Adicionar Item ao Estoque");
            Console.WriteLine("2. Listar Estoque");
            Console.WriteLine("Escolha uma opção: ");

            int opcao;

            // Tratamento para garantir que o usuário insira uma opção válida
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                return;
            }

            if (opcao == 1)
            {
                Console.WriteLine("Adicionando um item ao estoque...");

                // Solicita os dados do item a ser adicionado
                Console.Write("Informe o código do produto: ");
                int codigo = int.Parse(Console.ReadLine());

                // Procura o produto no cadastro de produtos
                var produto = cadProdutos.GetProduto(codigo); // Busca pelo produto usando GetProduto
                if (produto != null)
                {
                    // Produto encontrado, solicita a quantidade e o preço
                    Console.Write("Informe a quantidade do produto: ");
                    int quantidade = int.Parse(Console.ReadLine());

                    Console.Write("Informe o preço do produto: ");
                    decimal preco = decimal.Parse(Console.ReadLine());

                    // Cria o item de estoque
                    ItemEstoque item = new ItemEstoque
                    {
                        Codigo = produto.Id,  // Usando Id do produto para o código do item
                        NomeProduto = produto.Nome,
                        Quantidade = quantidade,
                        Preco = preco
                    };

                    // Adiciona o item ao estoque
                    estoque.AdicionarItem(item);
                }
                else
                {
                    Console.WriteLine("Produto não encontrado no cadastro!");
                }
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Listando itens do estoque...");
                estoque.ListarEstoque(); // Exibe todos os itens no estoque
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }
    }
}

