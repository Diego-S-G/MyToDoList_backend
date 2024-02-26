using Microsoft.AspNetCore.Mvc;
using MyToDoList.Application.Interfaces;
using MyToDoList.Domain.Dtos;
using MyToDoList.Domain.Entities;

namespace MyToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        public TarefaController(ITarefaService service)
        {
            _tarefaService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var entities = await _tarefaService.GetListAsync();

            if (entities == null)
            {
                return BadRequest();
            }

            return Ok(entities.Select(x => new { x.Id, x.Descricao, x.Finalizado }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetCompleteAsync(int id)
        {
            var entity = await _tarefaService.GetCompleteAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Tarefa { Id = entity.Id, Descricao = entity.Descricao, Finalizado = entity.Finalizado });
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostAsync(TarefaInsertDto tarefaDto)
        {
            var tarefa = new Tarefa
            {
                Descricao = tarefaDto.Descricao,
                Finalizado = tarefaDto.Finalizado
            };

            var entity = await _tarefaService.CreateAsync(tarefa);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Tarefa { Id = entity.Id, Descricao = entity.Descricao, Finalizado = entity.Finalizado });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Tarefa tarefa)
        {
            var entity = await _tarefaService.UpdateAsync(tarefa.Id, tarefa);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Tarefa { Id = entity.Id, Descricao = entity.Descricao, Finalizado = entity.Finalizado });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _tarefaService.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
