using D3___Avaliação.Models;
using D3___Avaliação.Repositories;
using System.IO;

namespace D3___Avaliação
{
    internal class Program
    {
        private const string path = "database/userLog.txt";
        static void Main(string[] args)
        {
            UserRepository _user = new();

            FileStream file = File.OpenWrite(path);

            LogRepository _log = new(file);

            string option, _option;

            do
            {
                Console.WriteLine("***************************");
                Console.WriteLine("Escolha uma das opções abaixo:\n");
                Console.WriteLine(" --> 1 : Acessar");
                Console.WriteLine(" --> 0 : Cancelar");

                option = Console.ReadLine();

                User user = new();

                switch (option)
                {
                    case "1":

                        Console.WriteLine("\nDigite seu email:");
                        user.Email = Console.ReadLine();
                        Console.WriteLine("\nDigite sua senha:");
                        user.Pwd = Console.ReadLine();

                        if (_user.Login(user))
                        {
                            _log.RegisterAccess(user);
                            Console.WriteLine("\nSucesso no login!\n");

                            do
                            {
                                Console.WriteLine("Escolha uma das opções abaixo:");

                                Console.WriteLine(" --> 1 : Deslogar");
                                Console.WriteLine(" --> 0 : Encerrar sistema");

                                _option = Console.ReadLine();

                                switch (_option)
                                {
                                    case "1":
                                        
                                        break;
                                    case "0":
                                        _log.RegisterLogout(user);

                                        file.Close();

                                        return;
                                    default:
                                        Console.WriteLine("Opção inválida! Tente novamente.\n");

                                        break;

                                }
                            } while (_option != "1");
                            
                        }

                        break;

                    default:
                        Console.WriteLine("Email e/ou Senha incorretos! Tente novamente..");
                        break;
                }

            } while (option != "0");

            file.Close();
        }
    }
}