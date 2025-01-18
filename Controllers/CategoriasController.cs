using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarefasApi.Data;
using TarefasApi.Models;

namespace TarefasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriasController(DataContext context)
        {
            _context = context;
        }
        // [HttpGet("GetAll")]
        // public async Task<IActionResult> GetAll()
        // {
        //     try
        //     {
        //         List<Categoria> categorias = await _context.TB_CATEGORIAS
        //         .Include(t => t.Tarefas)
        //         .ToListAsync();
        //         return Ok(categorias);
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message + " - " + ex.InnerException);
        //     }
        // }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Usuário não autenticado.");
                }

                int userIdInt = Convert.ToInt32(userId);

                List<Categoria> categorias = await _context.TB_CATEGORIAS
                    .Where(c => c.UsuarioId == userIdInt)
                    .Include(t => t.Tarefas)
                    .ToListAsync();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var categoria = await _context.TB_CATEGORIAS
                .Include(t => t.Tarefas)
                .FirstOrDefaultAsync(c => c.Id == id);

                if (categoria != null)
                {
                    return Ok(categoria);
                }
                else
                {
                    return BadRequest("Id não encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
        // [HttpPost]
        // public async Task<IActionResult> PostCategoria(Categoria categoria)
        // {
        //     try
        //     {
        //         if (categoria != null)
        //         {
        //             categoria.Tarefas = null;

        //             await _context.TB_CATEGORIAS.AddAsync(categoria);
        //             await _context.SaveChangesAsync();

        //             return Ok(categoria);
        //         }
        //         else
        //         {
        //             return BadRequest("Categoria inválida");
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message + " - " + ex.InnerException);
        //     }
        // }
        public async Task<IActionResult> PostCategoria(Categoria categoria)
        {
            try
            {
                if (categoria != null)
                {
                    var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                    categoria.UsuarioId = usuarioId;

                    categoria.Tarefas = null;

                    await _context.TB_CATEGORIAS.AddAsync(categoria);
                    await _context.SaveChangesAsync();

                    return Ok(categoria);
                }
                else
                {
                    return BadRequest("Categoria inválida");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                Categoria categoriaRemover = await _context.TB_CATEGORIAS.FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_CATEGORIAS.Remove(categoriaRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutById(Categoria novaCategoria)
        {
            try
            {
                _context.TB_CATEGORIAS.Update(novaCategoria);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

    }
}