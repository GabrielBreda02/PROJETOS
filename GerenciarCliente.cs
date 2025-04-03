using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmpresa
{
    public class GerenciarClientes
    {
        public static void Gerenciar(CadClientes cadClientes)
        {
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("----- Gerenciar Clientes -----");
                Console.WriteLine("1. Cadastrar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Buscar Cliente");
                Console.WriteLine("4. Alterar Cliente");
                Console.WriteLine("5. Excluir Cliente");
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
                        CadastrarCliente(cadClientes);
                        break;
                    case 2:
                        ListarClientes(cadClientes);
                        break;
                    case 3:
                        BuscarCliente(cadClientes);
                        break;
                    case 4:
                        AlterarCliente(cadClientes);
                        break;
                    case 5:
                        ExcluirCliente(cadClientes);
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

        private static void CadastrarCliente(CadClientes cadClientes)
        {
            Console.Clear();
            Console.WriteLine("----- Cadastrar Cliente -----");

            Console.Write("Informe o ID do cliente: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Informe o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o email do cliente: ");
            string email = Console.ReadLine();

            Console.Write("Informe o telefone do cliente: ");
            string telefone = Console.ReadLine();

            var cliente = new Cliente
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone
            };

            cadClientes.InserirCliente(cliente);
        }

        private static void ListarClientes(CadClientes cadClientes)
        {
            cadClientes.ListarClientes();
        }

        private static void BuscarCliente(CadClientes cadClientes)
        {
            Console.Clear();
            Console.WriteLine("----- Buscar Cliente -----");
            Console.Write("Informe o ID do cliente: ");
            int id = int.Parse(Console.ReadLine());

            var cliente = cadClientes.GetCliente(id);
            if (cliente != null)
            {
                Console.WriteLine(cliente.ToString());
            }
            else
            {
                Console.WriteLine("Cliente não encontrado!");
            }
        }

        private static void AlterarCliente(CadClientes cadClientes)
        {
            Console.Clear();
            Console.WriteLine("----- Alterar Cliente -----");
            Console.Write("Informe o ID do cliente que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            var cliente = cadClientes.GetCliente(id);
            if (cliente != null)
            {
                Console.Write("Informe o novo nome: ");
                cliente.Nome = Console.ReadLine();

                Console.Write("Informe o novo email: ");
                cliente.Email = Console.ReadLine();

                Console.Write("Informe o novo telefone: ");
                cliente.Telefone = Console.ReadLine();

                Console.WriteLine("Cliente alterado com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado!");
            }
        }

        private static void ExcluirCliente(CadClientes cadClientes)
        {
            Console.Clear();
            Console.WriteLine("----- Excluir Cliente -----");
            Console.Write("Informe o ID do cliente: ");
            int id = int.Parse(Console.ReadLine());

            if (cadClientes.ExcluirCliente(id))
            {
                Console.WriteLine("Cliente excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado!");
            }
        }
    }
}
