using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TarefasApi.Data;

namespace EstudosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }
        // private async Task<bool> UsuarioExistente(string username)
        // {
        //     if (await _context.t)
        // }
    }
}