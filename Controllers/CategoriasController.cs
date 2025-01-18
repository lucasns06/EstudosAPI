using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// testando 
        /// </summary>
        /// <returns>testando 2</returns>
        [HttpGet("GetByUsuario/{usuarioId}")]
        public async Task<IActionResult> GetCategoriasPorUsuario(int usuarioId)
        {
            try
            {
                // Filtra as categorias de um usuário específico
                List<Categoria> categorias = await _context.TB_CATEGORIAS
                    .Where(c => c.UsuarioId == usuarioId)  // Filtra pelo UsuarioId
                    .Include(t => t.Tarefas)
                    .ToListAsync();

                if (categorias != null && categorias.Any())
                {
                    return Ok(categorias);
                }
                else
                {
                    return Ok(new List<Categoria>()); // Retorna uma lista vazia se não houver categorias
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Categoria> categorias = await _context.TB_CATEGORIAS
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
        [HttpPost]
        public async Task<IActionResult> PostCategoria(Categoria categoria)
        {
            try
            {
                if (categoria != null)
                {
                    if (categoria.UsuarioId == 0)
                    {
                        return BadRequest("O ID do usuário é necessário.");
                    }

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