using System;
using System.Xml.Linq;

namespace pMiniBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            int op = 0;
            User user = new User();

            do
            {
                op = Menu();
                switch (op)
                {
                    case 1:
                        user.CreateAccont();
                        break;

                    case 2:
                        user.LoginAccount();
                        break;
                    case 3:
                        Console.WriteLine(user.ToString());
                        break;

                    default:
                        Console.WriteLine("Número Inválido!");
                        break;

                }
            } while (op != 0);

        }
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                                                  Banco Viniboy                                                         ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("\nSeja Bem Vindo ao MiniBanco Do Viniboy!\nPara iniarmos, digite como deseja entrar em nosso banco, \nse for novo por aqui faça um cadastro!\n");

            int opc;
            Console.WriteLine("[1] - Create Account");
            Console.WriteLine("[2] - Login Account");
           
           


            return opc = int.Parse(Console.ReadLine());
        }
    }
}
