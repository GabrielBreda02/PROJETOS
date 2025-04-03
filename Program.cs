using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Exercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" quais itens foram pegos, e a quantidade para o calculo:");
            string[] tabela = Console.ReadLine().Split(' ');
            int codigo = int.Parse(tabela[0]);
            int quantidade = int.Parse(tabela[1]);

            double total;

            if (codigo == 1)
            {
                total = quantidade * 4.0;
            }
            else if (codigo == 2)
            {
                total = quantidade * 4.5;
            }
            else if(codigo == 3)
            {
                total = quantidade * 5.0;
            }
            else if (codigo == 4)
            {
                total = quantidade * 2.0;
            } 
            else
            {
                total = quantidade * 1.5;
            }
            Console.WriteLine("total: R$" + total.ToString("f2", CultureInfo.InvariantCulture));
                
        }
    }
}
