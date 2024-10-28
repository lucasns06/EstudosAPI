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
        public DbSet<Projeto> TB_PROJETOS { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().ToTable("TB_TAREFAS");
            modelBuilder.Entity<Projeto>().ToTable("TB_PROJETOS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            modelBuilder.Entity<Tarefa>()
                .HasOne(p => p.Projeto)
                .WithMany(t => t.Tarefas)
                .HasForeignKey(p => p.ProjetoId);

            modelBuilder.Entity<Tarefa>().HasData(
                new Tarefa { Id = 1, Data = new DateTime(2024, 11, 28), Prioridade = Models.Enums.PrioridadeEnum.ALTA, Completo = false, Nome = "Equacoes", ProjetoId = 1 },
                new Tarefa { Id = 2, Data = new DateTime(2024, 11, 20), Prioridade = Models.Enums.PrioridadeEnum.MEDIA, Completo = false, Nome = "Potencia", ProjetoId = 1 },
                new Tarefa { Id = 3, Data = new DateTime(2024, 11, 10), Prioridade = Models.Enums.PrioridadeEnum.ALTA, Completo = false, Nome = "Revisao", ProjetoId = 2 }
            
            );

            modelBuilder.Entity<Projeto>().HasData(
                new Projeto { Id = 1, Nome = "Matematica" },
                new Projeto { Id = 2, Nome = "Fisica" }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario {Id = 1,  Nome = "Lucas"}
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}