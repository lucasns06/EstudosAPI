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
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase // Herda da ControllerBase, a classe que vai lidar com requisições HTTP e fornecer respostas.
{
    private readonly DataContext _context; //DataContext é a classe que vai gerar a conexão com o banco de dados.

    public TarefasController(DataContext context) //Obviamente o construtor
    {
        _context = context;
    }

    [HttpGet] 
    public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas() //Async: método assincrono
    {
        return await _context.TB_TAREFAS.ToListAsync(); // Retorna todas as tarefas
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tarefa>> GetTarefa(int id)
    {
        var tarefa = await _context.TB_TAREFAS.FindAsync(id);
        if (tarefa == null)
        {
            return NotFound();
        }
        return tarefa;
    }

    // Adicionar uma nova tarefa
    [HttpPost]
    public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
    {
        _context.TB_TAREFAS.Add(tarefa);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
    }

    // Atualizar uma tarefa existente
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTarefa(int id, Tarefa tarefa)
    {
        if (id != tarefa.Id)
        {
            return BadRequest();
        }

        _context.Entry(tarefa).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TB_TAREFAS.Any(e => e.Id == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // Remover uma tarefa
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTarefa(int id)
    {
        var tarefa = await _context.TB_TAREFAS.FindAsync(id);
        if (tarefa == null)
        {
            return NotFound();
        }

        _context.TB_TAREFAS.Remove(tarefa);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
}