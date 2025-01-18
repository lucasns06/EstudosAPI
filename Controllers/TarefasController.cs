using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TarefasApi.Data;
using TarefasApi.Models;

namespace TarefasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase // Herda da ControllerBase, a classe que vai lidar com requisições HTTP e fornecer respostas.
    {
        private readonly DataContext _context; //DataContext é a classe que vai gerar a conexão com o banco de dados.

        public TarefasController(DataContext context) //Obviamente o construtor
        {
            _context = context;
        }
        // [HttpGet("GetAll")]
        // public async Task<ActionResult> GetTarefas() //Async: método assincrono
        // {

        //     var lista = await _context.TB_TAREFAS
        //     .Include(t => t.Categoria)
        //     .Select(t => new
        //      {
        //          t.Id,
        //          t.Nome,
        //          t.DataTermino,
        //          t.Prioridade,
        //          t.Completo,
        //          t.CategoriaId,
        //          Categoria = new
        //          {
        //              t.Categoria.Id,
        //              t.Categoria.Nome
        //          }
        //      })
        //     .ToListAsync();
        //      // Retorna todas as tarefas
        //     return Ok(lista);
        // }
        [HttpGet("GetByUsuario2/{usuarioId}")]
        public async Task<IActionResult> GetTarefasPorCategorias(int usuarioId)  // Mudando para usuarioId
        {
            try
            {
                // Filtra as categorias de um usuário específico
                List<Tarefa> tarefas = await _context.TB_TAREFAS
                    .Where(c => c.Categoria.UsuarioId == usuarioId)  // Usa usuarioId para filtrar tarefas
                    .Include(t => t.Categoria)
                    .ToListAsync();

                if (tarefas != null && tarefas.Any())
                {
                    return Ok(tarefas);
                }
                else
                {
                    return Ok(new List<Tarefa>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTarefa(int id)
        {
            Tarefa lista = await _context.TB_TAREFAS
            .Include(t => t.Categoria)
            .FirstOrDefaultAsync(t => t.Id == id);

            return Ok(lista);
        }

        // Adicionar uma nova tarefa
        [HttpPost]
        public async Task<ActionResult> PostTarefa(Tarefa tarefa)
        {
            try
            {
                if (tarefa.Completo == true)
                {
                    throw new Exception("Não faz sentido criar uma tarefa completa.");
                }

                if (string.IsNullOrEmpty(tarefa.Nome))
                {
                    throw new Exception("O nome da tarefa não pode ser vazio.");
                }
                await _context.TB_TAREFAS.AddAsync(tarefa);
                await _context.SaveChangesAsync();

                return Ok(tarefa.Id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException?.Message);
            }
        }

        // Atualizar uma tarefa existente
        [HttpPut]
        public async Task<IActionResult> Update(Tarefa novaTarefa)
        {
            try
            {
                _context.TB_TAREFAS.Update(novaTarefa);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        // Remover uma tarefa
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Tarefa aRemover = await _context.TB_TAREFAS.FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_TAREFAS.Remove(aRemover);
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