using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosDev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) {
            Console.WriteLine("COLOQUE A HORA DE ENTRADA E SAIDA DO JOGO: ");
            string[] horas = Console.ReadLine().Split(' ');
            int horaInicial = int.Parse(horas[0]);
            int horaFinal = int.Parse(horas[1]);
            int duracao;

            if (horaInicial < horaFinal ) {
            duracao = horaFinal - horaInicial;
            }
            else { 
                duracao = 24 - horaInicial + horaFinal;
                }

            Console.WriteLine(" O JOGO DUROU " + duracao + "HORA(S)");

                Console.WriteLine("deseja encerrar ? DIGITE 'S' PARA SAIR OU QUALQUER OUTRA TECLA PARA CONTINUAR.");

                if(Console.ReadLine(). ToLower()== "s")
                {
                break;
                }
            }
        }
    }
}

