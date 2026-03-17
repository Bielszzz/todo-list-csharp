using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_DoList_CSharp.Models;
using System.Text.Json;
using System.IO;

namespace To_DoList_CSharp.Services
{
    public class TarefaService
    {
        private List<Tarefa> tarefas = new List<Tarefa>();
        private int proximoId = 1;
        private string ArquivoTarefas = "tarefas.json";

        public TarefaService()
        {
            CarregarTarefas();
        }

        public void CriarTarefa()
        {

            Console.Write("Título da Tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição da Tarefa: ");
            string descricao = Console.ReadLine();

            Tarefa tarefa = new Tarefa()
            {
                Id = proximoId++,
                Titulo = titulo,
                Descricao = descricao,
                Concluida = false,
                DataCriacao = DateTime.Now
            };

            tarefas.Add(tarefa);
            SalvarTarefas();

            Console.WriteLine("\nTarefa criada com sucesso!");

        }

        public void ListarTarefa()
        {
            if (tarefas.Count == 0)
                Console.WriteLine("\nNenhuma tarefa encontrada!");

            else
            {
                foreach (Tarefa t in tarefas)
                {
                    string status = t.Concluida ? "Sim" : "Não";

                    Console.WriteLine("==========================================");
                    Console.WriteLine($"ID: {t.Id}");
                    Console.WriteLine($"Título: {t.Titulo}");
                    Console.WriteLine($"Descrição: {t.Descricao}");
                    Console.WriteLine($"Concluida: {status}");
                    Console.WriteLine($"Criada em {t.DataCriacao}");
                    Console.WriteLine("==========================================");
                }
            }
           
        }

        public void ConcluirTarefa()
        {
            Console.Write("\nDigite o ID da Tarefa para Concluí-lá: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("\nErro! Digite um ID válido!");
                Console.Write("Digite o ID da Tarefa para Concluí-lá: ");
            }


            Tarefa tarefa = tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa != null)
            {
                tarefa.Concluida = true;
                SalvarTarefas();
                Console.WriteLine($"\nTarefa: {tarefa.Titulo} foi concluida com sucesso!");
            }

            else Console.WriteLine("\nTarefa não encontrada, tente novamente!");


        }

        public void DeletarTarefa()
        {
            Console.Write("\nDigite o ID da tarefa a ser deletada: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                Console.WriteLine("\nErro! Digite um ID válido!");
                Console.Write("Tente novamente: ");
            }

            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa != null)
            {
                Console.WriteLine($"\nTarefa encontrada:");
                string status = tarefa.Concluida ? "Sim" : "Não";

                Console.WriteLine("==========================================");
                Console.WriteLine($"ID: {tarefa.Id}");
                Console.WriteLine($"Título: {tarefa.Titulo}");
                Console.WriteLine($"Descrição: {tarefa.Descricao}");
                Console.WriteLine($"Concluida: {status}");
                Console.WriteLine($"Criada em {tarefa.DataCriacao}");
                Console.WriteLine("==========================================");

                Console.WriteLine($"\nTem certeza que deseja excluir a tarefa: '{tarefa.Titulo}'? (s / n): ");
                string decisao = Console.ReadLine().ToLower();
                while (decisao != "s" && decisao != "n")
                {
                    Console.WriteLine("\nOpção INVÁLIDA!");
                    Console.WriteLine("##### Digite 's' para SIM e 'n' para NÃO ##### ");
                    Console.WriteLine("Tem certeza que deseja excluir? (s / n): ");
                    decisao = Console.ReadLine().ToLower();
                }


                if (decisao == "s")
                {
                    tarefas.Remove(tarefa);
                    SalvarTarefas();
                    Console.WriteLine("\nTarefa excluída com sucesso!");
                } 

                else
                {
                    Console.WriteLine("\nExclusão Cancelada!");
                }

            }   else Console.WriteLine("\nTarefa não encontrada!");
        }



        private void SalvarTarefas()
        {
            string json = JsonSerializer.Serialize(tarefas);

            File.WriteAllText(ArquivoTarefas, json);
        }

        private void CarregarTarefas()
        {
            if (File.Exists(ArquivoTarefas))
            {
                string json = File.ReadAllText(ArquivoTarefas);
                tarefas = JsonSerializer.Deserialize<List<Tarefa>>(json) ?? new List<Tarefa>();

                if (tarefas.Count > 0)
                    proximoId = tarefas.Max(t => t.Id) + 1;
            }

        }

        
    }
}