using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudosAPI.Utils;
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
        public DbSet<Usuario> TB_USUARIOS { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().ToTable("TB_TAREFAS");
            modelBuilder.Entity<Categoria>().ToTable("TB_CATEGORIAS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            //relacionamento
            modelBuilder.Entity<Usuario>()
           .HasMany(e => e.Categorias)
           .WithOne(e => e.Usuario)
           .HasForeignKey(e => e.UsuarioId)
           .IsRequired(false);

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
                new Tarefa { Id = 1, Nome = "Estudar Matemática", DataTermino = "05/10",  Prioridade = PrioridadeEnum.ALTA, Completo = false, CategoriaId = 1 },
                new Tarefa { Id = 2, Nome = "Revisar Física", DataTermino = "11/10", Prioridade = PrioridadeEnum.MEDIA, Completo = false, CategoriaId = 2 },
                new Tarefa { Id = 3, Nome = "Regra de três", DataTermino = "28/11", Prioridade = PrioridadeEnum.BAIXA, Completo = false, CategoriaId = 1 }
            );

            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);

            
            //Define que se o Perfil não for informado, o valor padrão será jogador
            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Jogador");

            base.OnModelCreating(modelBuilder);
        }
    }

}