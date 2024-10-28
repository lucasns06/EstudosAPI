using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TarefasApi.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome {get; set; } = string.Empty;
        public ICollection<Tarefa> Tarefas { get; set;}
        public Projeto(){}
        public Projeto(int Id, string Nome){
            this.Id = Id;
            this.Nome = Nome;
        }
    }
}