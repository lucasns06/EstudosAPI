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
    public class ProjetosController : ControllerBase
    {
        //Crud
        private readonly DataContext _context;
        public ProjetosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjeto()
        {
            var projetos = await _context.TB_PROJETOS.Include(p => p.Tarefas).ToListAsync(); return Ok(projetos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectById(int id)
        {
            var projeto = await _context.TB_PROJETOS.Include(p => p.Tarefas).FirstOrDefaultAsync(p => p.Id == id);
            if (projeto == null) { return NotFound(); }
            return Ok(projeto);
        }
        [HttpPost]
        public async Task<ActionResult<Projeto>> PostProject(Projeto projeto)
        {
            foreach (var tarefa in projeto.Tarefas)
            {
                _context.Entry(tarefa).State = EntityState.Added;
            }

            _context.TB_PROJETOS.Add(projeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostProject), new { id = projeto.Id }, projeto);
        }

    }
}