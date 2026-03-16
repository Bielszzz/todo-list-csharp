using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_DoList_CSharp.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public bool Concluida { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
