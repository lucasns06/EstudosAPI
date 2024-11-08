using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TarefasApi.Models;
using TarefasApi.Models.Enums;

namespace TarefasApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Tarefa> TB_TAREFAS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().ToTable("TB_TAREFAS");

            modelBuilder.Entity<Tarefa>().HasData(
            new Tarefa
            {
                Id = 1,
                Data = new DateTime(2024, 11, 15),
                Nome = "Estudar Matemática",
                Prioridade = PrioridadeEnum.ALTA,
                Completo = false
            },
            new Tarefa
            {
                Id = 2,
                Data = new DateTime(2024, 11, 16),
                Nome = "Revisar Física",
                Prioridade = PrioridadeEnum.MEDIA,
                Completo = false
            },
            new Tarefa
            {
                Id = 3,
                Data = new DateTime(2024, 11, 17),
                Nome = "Ler sobre Química",
                Prioridade = PrioridadeEnum.BAIXA,
                Completo = false
            }
        );
            base.OnModelCreating(modelBuilder);
        }
    }

}