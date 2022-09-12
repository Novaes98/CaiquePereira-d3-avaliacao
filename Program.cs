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
            bool loginUser;

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
                    case "0":
                        break;
                    case "1":

                        do
                        {
                            Console.WriteLine("\nDigite seu email:");
                            user.Email = Console.ReadLine();
                            Console.WriteLine("\nDigite sua senha:");
                            user.Pwd = Console.ReadLine();

                            if (loginUser = _user.Login(user))
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
                                            _log.RegisterLogout(user);

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
                            else
                            {
                                Console.WriteLine("\nEmail e/ou Senha incorretos! Por favor, tente novamente...");
                            }
                        } while (!loginUser);
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.\n");
                        break;
                }

            } while (option != "0");
            
            file.Close();
        }
    }
}