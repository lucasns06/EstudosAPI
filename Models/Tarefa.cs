using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TarefasApi.Models.Enums;

namespace TarefasApi.Models
{
    public class Tarefa
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Nome { get; set; } = string.Empty;
    public PrioridadeEnum Prioridade { get; set; }
    public bool Completo { get; set; }
}

}