using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TarefasApi.Models;

namespace TarefasApi.Data
{
    public class DataContext : DbContext // herança 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) //construtor
        {

        }
        public DbSet<Tarefa> TB_TAREFAS { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tarefa>().ToTable("TB_TAREFAS");

            //relacionamentos 
            modelBuilder.Entity<Tarefa>().HasData(
                new Tarefa { Id = 1, Data = new DateTime(2024, 11, 28), prioridade = Models.Enums.PrioridadeEnum.ALTA, Completo = false, Nome = "Matematica, Equacoes" },
                new Tarefa { Id = 2, Data = new DateTime(2024, 11, 20), prioridade = Models.Enums.PrioridadeEnum.MEDIA, Completo = false, Nome = "Matematica, Potencia" }
            );
        }
    }
}