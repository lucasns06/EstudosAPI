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
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase // Herda da ControllerBase, a classe que vai lidar com requisições HTTP e fornecer respostas.
    {
        private readonly DataContext _context; //DataContext é a classe que vai gerar a conexão com o banco de dados.

        public TarefasController(DataContext context) //Obviamente o construtor
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetTarefas() //Async: método assincrono
        {

            List<Tarefa> lista = await _context.TB_TAREFAS.ToListAsync(); // Retorna todas as tarefas
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTarefa(int id)
        {
            Tarefa a = await _context.TB_TAREFAS.FirstOrDefaultAsync(aBusca => aBusca.Id == id);
            return Ok(a);
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