using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_DoList_CSharp.Models;
using System.Text.Json;

namespace To_DoList_CSharp.Services
{
    public class TarefaService
    {
        private List<Tarefa> tarefas = new List<Tarefa>();
        private int proximoId = 1;


        public void CriarTarefa()
        {

            Console.Write("Titulo da Tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição da Tarefa");
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

            Console.WriteLine("Tarefa criada com sucesso!");

        }

        public void ListarTarefa()
        {
            foreach (Tarefa t in tarefas)
            {
                string status = t.Concluida ? "✔" : "❌";

                Console.WriteLine("==========================================");
                Console.WriteLine($"ID: {t.Id}");
                Console.WriteLine($"Titulo: {t.Titulo}");
                Console.WriteLine($"Descrição: {t.Descricao}");
                Console.WriteLine($"Concluida: {status}");
                Console.WriteLine($"Criada em {t.DataCriacao}");
                Console.WriteLine("==========================================");
            }
        }

        public void ConcluirTarefa()
        {
            Console.Write("Digite o ID da Tarefa para Concluí-lá: ");
            int id;
            while (!int.TryParse( Console.ReadLine(), out id ) || id < 0)
            {
                Console.WriteLine("Erro! Digite um número inteiro maior ou igual a zero.");
                Console.Write("Tente novamente: ");
            }


            Tarefa tarefa = tarefas.FirstOrDefault( t => t.Id == id );

            if (tarefa != null)
            {
                tarefa.Concluida = true;
                Console.WriteLine($"Tarefa: {tarefa.Titulo} foi concluida com sucesso!");
            }

            else Console.WriteLine("Tarefa não encontrada, tente novamente!");









        }
    }
}