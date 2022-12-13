using System;
using System.Xml.Linq;

namespace pMiniBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------MiniBanco Viniboy---------");
            Console.WriteLine("Seja Bem Vindo ao MiniBanco Do Viniboy!\nPara iniarmos, digite como deseja entrar em nosso banco, \nse for novo por aqui faça um cadastro!\n");

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
                        user.loginAccount();
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

            int opc;
            Console.WriteLine("1 - Create");
            Console.WriteLine("2 - Login");
            Console.WriteLine("3 - exibir contas");
           


            return opc = int.Parse(Console.ReadLine());
        }
    }
}
