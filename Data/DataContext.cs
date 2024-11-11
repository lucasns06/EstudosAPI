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
        public DbSet<Categoria> TB_CATEGORIAS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().ToTable("TB_TAREFAS");
            modelBuilder.Entity<Categoria>().ToTable("TB_CATEGORIAS");

              modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Tarefas)  
                .WithOne(t => t.Categoria) 
                .HasForeignKey(t => t.CategoriaId);

            modelBuilder.Entity<Categoria>().HasData
            (
                new Categoria { Id = 1, Nome = "Matematica" },
                new Categoria { Id = 2, Nome = "Fisica" }
            );

            modelBuilder.Entity<Tarefa>().HasData
            (
                new Tarefa { Id = 1, DataTermino = "05/10", Nome = "Estudar Matemática", Prioridade = PrioridadeEnum.ALTA, Completo = false, CategoriaId = 1 },
                new Tarefa { Id = 2, DataTermino = "11/10", Nome = "Revisar Física", Prioridade = PrioridadeEnum.MEDIA, Completo = false, CategoriaId = 2 },
                new Tarefa { Id = 3, DataTermino = "28/11", Nome = "Regra de três", Prioridade = PrioridadeEnum.BAIXA, Completo = false, CategoriaId = 1 }
            );


            base.OnModelCreating(modelBuilder);
        }
    }

}