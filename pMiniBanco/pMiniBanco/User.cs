using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace pMiniBanco
{
    internal class User
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime Aniversario { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }


        public static List<User> ListUser = new List<User>();


        public User()
        {

        }

        public User(string name, string cpf, DateTime aniversario, string login, string password, double balance)
        {
            //parametro para criar um novo usuário
            this.Name = name;
            this.CPF = cpf;
            this.Aniversario = aniversario;
            this.Login = login;
            this.Password = password;
            this.Balance = balance;
        }

        public void CreateAccont()
        {
            User conta = new User();
            Console.Clear();
            Cabecalho();
            Console.WriteLine("\nBem vindo a ciação de conta no banco viniboy, vamos começar: \n");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("|       Dados Pessoais      |");
            Console.WriteLine("-----------------------------");
            Console.Write("Digite seu nome: ");
            Name = Console.ReadLine();
            Console.Write("Digite seu CPF: ");
            CPF = Console.ReadLine();

            while (!ValidateCPF(CPF))
            {
                Console.WriteLine("CPF INVÁLIDO!\nInsira novamente um CPF Válido: ");
                CPF = Console.ReadLine();
            }

            Console.Write("Digite sua data de Aniversário (dd/mm/aaaa): ");
            Aniversario = DateTime.Parse(Console.ReadLine());

            while (!ValidateAge(Aniversario))
            {
                Console.WriteLine("CADASTRO INVALIDO! USUARIO MENOR DE IDADE. TECLE [alguma tecla] PARA SAIR");
                Console.ReadKey();
                CreateAccont();
            }


            Console.WriteLine("-----------------------------");
            Console.WriteLine("|      Dados da conta:      |");
            Console.WriteLine("-----------------------------");
            Console.Write("Crie um Usuário: ");
            Login = Console.ReadLine();


            Console.Write("Crie uma senha (A senha deve conter 4 números): ");
            Password = Console.ReadLine();

            while (Password.Length != 4)
            {
                Console.WriteLine("A senha deve ter 4 digitos ");
                Password = Console.ReadLine();

            }



            ListUser.Add(new User(Name, CPF, Aniversario, Login, Password, Balance = 0));


            Console.Clear();
            Cabecalho();
            Console.WriteLine("Os Dados foram armazenados com sucesso!");
            Console.WriteLine($"\nalguns desses dados no cadastro são: \nNome: {Name}\nCPF: {CPF}\nAniversário: {Aniversario}\n\nUsuário: {Login}\nSenha: {Password}\n");
            Console.WriteLine("Precione [enter] para sair");
            Console.ReadKey();

        }
        public void LoginAccount()
        {
            Console.Clear();
            Cabecalho();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("|      Dados De Login:      |");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("\nDigite seu usuário: ");
            string login = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            if (ValidateAccount(login, senha))
            {
                HomeScreen(login, senha);
            }
            else
            {
                Console.WriteLine("Login Inválido!\nTente novamente:");
                LoginAccount();
            }

        }

        public void HomeScreen(string login, string senha)
        {
            foreach (User usuarioLogin in ListUser)
            {

                if (usuarioLogin.Login == login && usuarioLogin.Password == senha)
                {
                    Console.Clear();
                    Cabecalho();
                    Console.WriteLine($"Fico feliz em estar aqui {Name}!\n");
                    Console.WriteLine($"Dados do usuário: \nNome:{usuarioLogin.Name}\nAniversário: {usuarioLogin.Aniversario}\nCPF: {usuarioLogin.CPF}\n\n");

                    Console.WriteLine("Operações bancarias: ");
                    Console.WriteLine("[1] - Ver saldo");
                    Console.WriteLine("[2] - Sacar");
                    Console.WriteLine("[3] - Depositar");
                    Console.WriteLine("[4] - Voltar ao Menu Incial");

                    int opc = int.Parse(Console.ReadLine());


                    switch (opc)
                    {
                        case 1:
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine($"\nSeu saldo é: {usuarioLogin.Balance}");
                            Console.WriteLine("Precione [enter] para voltar");
                            Console.ReadKey();
                            HomeScreen(login, senha);
                            break;
                        case 2:
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine($"\nSeu saldo é: {usuarioLogin.Balance}");
                            Console.Write("Informe quantos reais deseja sacar: ");
                            double sacar = double.Parse(Console.ReadLine());

                            while (sacar > usuarioLogin.Balance)
                            {
                                Console.WriteLine("Não a esse valor disponível em sua conta!\n");
                                Console.Write("Informe quantos reais deseja sacar: ");

                                sacar = double.Parse(Console.ReadLine());


                            }

                            usuarioLogin.Balance = usuarioLogin.Balance - sacar;


                            Console.WriteLine($"Voce sacou: R${sacar}\nSeu saldo atual é: R${usuarioLogin.Balance}\n");
                            Console.WriteLine("Precione [enter] para voltar");
                            Console.ReadKey();
                            HomeScreen(login, senha);




                            break;
                        case 3:
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine($"\nSeu saldo é: R${usuarioLogin.Balance}");
                            Console.Write("Informe quantos reais deseja depositar: ");
                            double depositar = int.Parse(Console.ReadLine());

                            usuarioLogin.Balance = usuarioLogin.Balance + depositar;

                            Console.WriteLine($"Voce depositou: R${depositar}\nSeu saldo atual é: R${usuarioLogin.Balance}\n");
                            Console.WriteLine("Precione [enter] para voltar");
                            Console.ReadKey();
                            HomeScreen(login, senha);

                            break;
                        case 4:
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine("\nPrecione [enter] para sair");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Inválido, tente novamente:");
                            break;

                    }


                }

            }

        }


        public bool ValidateAccount(string login, string senha)
        {

            foreach (User usuarioLogin in ListUser)
            {

                if (usuarioLogin.Login == login && usuarioLogin.Password == senha)
                {
                    return true;
                }

            }

            return false;

        }

        public bool ValidateCPF(string CPF)
        {
            string valor = CPF.Replace(".", "");

            valor = valor.Replace("-", "");



            if (valor.Length != 11)

                return false;



            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;



            if (igual || valor == "12345678909")

                return false;



            int[] numeros = new int[11];



            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());



            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];



            int resultado = soma % 11;



            if (resultado == 1 || resultado == 0)

            {

                if (numeros[9] != 0)

                    return false;

            }

            else if (numeros[9] != 11 - resultado)

                return false;



            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];



            resultado = soma % 11;



            if (resultado == 1 || resultado == 0)

            {

                if (numeros[10] != 0)

                    return false;

            }

            else

                if (numeros[10] != 11 - resultado)

                return false;



            return true;

        }

        public override string ToString()
        {
            return $"{Name} {CPF} {Aniversario} {Login} {Password}";
        }

        public bool ValidateAge(DateTime Aniversario)
        {

            User user = new User();
            int age = (DateTime.Now.Year - user.Aniversario.Year);
            if (age < 18)
            {
                Console.WriteLine("Menor de idade!!!");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void Cabecalho()
        {
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                                                  Banco Viniboy                                                         ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }

    }
}
