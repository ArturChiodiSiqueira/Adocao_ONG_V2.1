using Adocao_ONG_V2._1.Controller;
using Adocao_ONG_V2._1.Model;
using Adocao_ONG_V2._1.Service;
using System;

namespace Adocao_ONG_V2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            Animal animal = new Animal();
            Pessoa pessoa = new Pessoa();
            int opcao = 10;
            do
            {
                Console.Clear();
                Console.WriteLine(" |===============  MENU  ===============|");
                Console.WriteLine(" |Opção 1 : Cadastrar Pessoa            |");
                Console.WriteLine(" |Opção 2 : Alterar Dados Pessoa        |");
                Console.WriteLine(" |Opção 3 : Mostrar Pessoas Cadastradas |");
                Console.WriteLine(" |======================================|");
                Console.WriteLine(" |Opção 4 : Cadastrar Animal            |");
                Console.WriteLine(" |Opção 5 : Alterar Dados Animal        |");
                Console.WriteLine(" |Opção 6 : Mostrar Animais Cadastrados |");
                Console.WriteLine(" |======================================|");
                Console.WriteLine(" |Opção 7 : Adotar um Animal            |");
                Console.WriteLine(" |Opção 8 : Mostrar Adoções             |");
                Console.WriteLine(" |Opção 9 : Mostrar Animais Disponiveis |");
                Console.WriteLine(" |======================================|");
                Console.WriteLine(" |Opção 0 : Sair                        |");
                Console.WriteLine(" |======================================|");

                Console.Write("\n Informe a opção: ");

                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }

                switch (opcao)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        Console.Clear();
                        //new ONGController().AdicionarPessoa();
                        pessoa.CadastraPessoa();
                        new PessService().Add(pessoa);
                        Console.WriteLine("Cadastro Concluído\n");
                        Console.WriteLine("\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                        Console.ReadKey();
                        MostrarMenu();
                        break;

                    case 2:
                        Console.Clear();
                        new ONGController().AtualizarPessoa();
                        MostrarMenu();
                        break;

                    case 3:
                        Console.Clear();
                        new ONGController().SelecionarPessoa();
                        //new PessService().GetAll().ForEach(x => Console.WriteLine(x));
                        MostrarMenu();
                        break;

                    case 4:
                        Console.Clear();
                        //new ONGController().AdicionarAnimal();
                        animal.CadastraAnimal();
                        new AniService().Add(animal);
                        Console.WriteLine("Cadastro Concluído\n");
                        Console.WriteLine("\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                        Console.ReadKey();
                        MostrarMenu();
                        break;

                    case 5:
                        Console.Clear();
                        new ONGController().AtualizarAnimal();
                        MostrarMenu();
                        break;

                    case 6:
                        Console.Clear();
                        new ONGController().SelecionarAnimal();
                        //new AniService().GetAll().ForEach(x => Console.WriteLine(x));
                        Console.ReadKey();
                        MostrarMenu();
                        break;

                    case 7:
                        Console.Clear();
                        new ONGController().Adotar();
                        MostrarMenu();
                        break;

                    case 8:
                        Console.Clear();
                        new ONGController().SelecionarAdotados();
                        MostrarMenu();
                        break;

                    case 9:
                        Console.Clear();
                        new ONGController().SelecionarDisponiveis();
                        MostrarMenu();
                        break;

                    default:
                        Console.Write("\n Opcao Inválida! Aperte [ENTER] para executar novamente.");
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}
