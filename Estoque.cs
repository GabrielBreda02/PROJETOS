using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmpresa
{
    public class Estoque
    {
        // Vetor de 50 posições para armazenar os itens do estoque
        private ItemEstoque[] itensEstoque;
        private int contador;

        public Estoque()
        {
            // Inicializa o vetor com 50 posições
            itensEstoque = new ItemEstoque[50];
            contador = 0; // Inicia o contador para controlar a quantidade de itens no estoque
        }

        // Método para adicionar um item ao estoque
        public void AdicionarItem(ItemEstoque item)
        {
            if (contador < 50) // Verifica se há espaço no estoque
            {
                itensEstoque[contador] = item; // Adiciona o item na próxima posição disponível
                contador++; // Incrementa o contador
                Console.WriteLine("Item adicionado ao estoque com sucesso!");
            }
            else
            {
                Console.WriteLine("Estoque cheio! Não é possível adicionar mais itens.");
            }
        }

        // Método para listar todos os itens do estoque
        public void ListarEstoque()
        {
            Console.Clear();
            Console.WriteLine("----- Lista de Itens no Estoque -----");

            if (contador == 0)
            {
                Console.WriteLine("Nenhum item no estoque.");
                return;
            }

            // Exibe todos os itens cadastrados no estoque
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine(itensEstoque[i].ToString());
            }
        }

        // Método para verificar se existe produto no estoque
        public ItemEstoque BuscarItem(int codigo)
        {
            for (int i = 0; i < contador; i++)
            {
                if (itensEstoque[i].Codigo == codigo)
                {
                    return itensEstoque[i];
                }
            }
            return null; // Retorna null se o item não for encontrado
        }
    }

    // Classe que representa um item no estoque
    public class ItemEstoque
    {
        public int Codigo { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        // Exibe os detalhes do item
        public override string ToString()
        {
            return $"Código: {Codigo}, Nome: {NomeProduto}, Quantidade: {Quantidade}, Preço: {Preco:C}";
        }
    }
}

