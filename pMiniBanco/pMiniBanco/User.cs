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


        List<User> ListUser = new List<User>();

        public User()
        {

        }

        public User(string name, string cpf, DateTime aniversario, string login, string password)
        {
            //parametro para criar um novo usuário
            this.Name = name;
            this.CPF = cpf;
            this.Aniversario = aniversario;
            this.Login = login;
            this.Password = password;
        }

        public void CreateAccont()
        {
           
            Console.Clear();
            Console.WriteLine("-------------Criação de conta MiniBanco Viniboy-------------");
            Console.WriteLine("Bem vindo a ciação de conta no banco viniboy, vamos começar: \n");
            Console.Write("Digite seu nome: ");
            Name = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Digite seu CPF: ");
            CPF = Console.ReadLine();

            while (!ValidateCPF(CPF))
            {
                Console.WriteLine("CPF INVÁLIDO!\nInsira novamente um CPF Válido: ");
                CPF = Console.ReadLine();
            }
            Console.WriteLine("");

            Console.Write("Data de Aniversário dd/mm/aaaa: ");
            Aniversario = DateTime.Parse(Console.ReadLine());

            while(!ValidateAge(Aniversario))
            {
                Console.WriteLine("CADASTRO INVALIDO! USUARIO MENOR DE IDADE. TECLE [alguma tecla] PARA SAIR");
                Console.ReadKey();
                CreateAccont();
            }


            Console.WriteLine("");
            Console.Write("Crie um Usuário: ");
            Login = Console.ReadLine();


            Console.Write("Crie uma senha: ");
            Password = Console.ReadLine();

            while (Password.Length != 4)
            {
                Console.WriteLine("A senha deve ter 4 digitos ");
                Password = Console.ReadLine();

            }



            ListUser.Add(new User(Name, CPF, Aniversario, Login, Password));

            foreach (User usuario in ListUser)
            {
                Console.WriteLine(usuario.ToString());
            }

        }
        public void loginAccount()
        {
            Console.WriteLine("Digite seu usuário: ");
            string login = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            if(!ValidateAccount(login, senha))
            {
                Console.WriteLine("Verdadeiro");
            }
            else
            {
                Console.WriteLine("Falso");
            }

        }

        public bool ValidateAccount(string login, string senha)
        {
            bool achei = false;

            foreach (User usuarioLogin in ListUser)
            {

                if (usuarioLogin.Login == login && usuarioLogin.Password == senha)
                { 
                    achei = true;

                }
                else 
                {
                    achei = false;
                }


            }

            return achei;

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



    }
}
