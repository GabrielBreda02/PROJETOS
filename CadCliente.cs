using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmpresa
{
    public class CadClientes
    {
        private List<Cliente> clientes;

        public CadClientes()
        {
            clientes = new List<Cliente>();
        }

        public void InserirCliente(Cliente cliente)
        {
            clientes.Add(cliente);
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        public void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("----- Lista de Clientes -----");

            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            foreach (var cliente in clientes)
            {
                Console.WriteLine(cliente.ToString());
            }
        }

        public Cliente GetCliente(int id)
        {
            return clientes.Find(c => c.Id == id);
        }

        public bool ExcluirCliente(int id)
        {
            var cliente = GetCliente(id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
                return true;
            }
            return false;
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Email: {Email}, Telefone: {Telefone}";
        }
    }
}
