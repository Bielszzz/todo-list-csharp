using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;
using To_DoList_CSharp.Services;

namespace To_DoList_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TarefaService service = new TarefaService();

            while(true)
            {
                Console.WriteLine("\n========= Lista de Tarefas =========");
                Console.WriteLine("Criar Tarefa ---- 1");
                Console.WriteLine("Listar Tarefas -- 2");
                Console.WriteLine("Concluir Tarefa - 3");
                Console.WriteLine("Deletar Tarefa -- 4");
                Console.WriteLine("Sair ------------ 0");   
                Console.Write("\n===== Escolha a opção desejada:  ");
                int opcao;
                while (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("ERRO! Digite uma opção válida!");
                    Console.Write("Escolha a opção desejada: ");
                }
                

                switch (opcao)
                {
                    case 1:
                        service.CriarTarefa();
                        break;

                    case 2:
                        service.ListarTarefa();
                        break;

                    case 3:
                        service.ConcluirTarefa();
                        break;

                    case 4:
                        service.DeletarTarefa();
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;

                Console.ReadKey();
                }       
            }
        }
    }
}
