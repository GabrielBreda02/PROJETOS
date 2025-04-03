using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace EstruturaRepetitivaWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Digite um numero :");
            double x = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            while (x >= 0.0)
            {
                double raiz = Math.Sqrt(x);
                Console.WriteLine(raiz.ToString("f3", CultureInfo.InvariantCulture));
                Console.Write("Digite outro numero : ");
                x = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);   
            }
            Console.WriteLine("numero negativo ! ");
        }
    }
}
