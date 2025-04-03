using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmpresa
{
    public class CadProdutos
    {
        private List<Produto> produtos;

        public CadProdutos()
        {
            produtos = new List<Produto>();
        }

        // Método para adicionar um produto à lista
        public void InserirProduto(Produto produto)
        {
            produtos.Add(produto);
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        // Método para listar todos os produtos
        public void ListarProdutos()
        {
            Console.Clear();
            Console.WriteLine("----- Lista de Produtos -----");

            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            foreach (var produto in produtos)
            {
                Console.WriteLine(produto.ToString());
            }
        }

        // Método para buscar um produto pelo ID
        public Produto GetProduto(int id)
        {
            return produtos.Find(p => p.Id == id);
        }

        // Método para excluir um produto pelo ID
        public bool ExcluirProduto(int id)
        {
            var produto = GetProduto(id);
            if (produto != null)
            {
                produtos.Remove(produto);
                return true;
            }
            return false;
        }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Preço: {Preco:C}";
        }
    }


}
