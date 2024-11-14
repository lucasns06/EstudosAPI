using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TarefasApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? Foto { get; set;}
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? DataAcesso { get; set; }
        
        [NotMapped] // DataAnnotations
        public string PasswordString { get; set; } = string.Empty;
        
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();
        public string Perfil { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}