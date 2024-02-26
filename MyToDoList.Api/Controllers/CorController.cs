using Microsoft.AspNetCore.Mvc;
using MyToDoList.Application.Interfaces;
using MyToDoList.Domain.Dtos;
using MyToDoList.Domain.Entities;

namespace MyToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorController : ControllerBase
    {
        private readonly ICorService _corService;
        public CorController(ICorService service)
        {
            _corService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var entities = await _corService.GetListAsync();

            if (entities == null)
            {
                return BadRequest();
            }

            return Ok(entities.Select(x => new { x.Id, x.Nome, x.Codigo }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cor>> GetCompleteAsync(int id)
        {
            var entity = await _corService.GetCompleteAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Cor { Id = entity.Id, Nome = entity.Nome, Codigo = entity.Codigo });
        }

        [HttpPost]
        public async Task<ActionResult<Cor>> PostAsync(CorInsertDto corDto)
        {
            var cor = new Cor
            {
                Nome = corDto.Nome,
                Codigo = corDto.Codigo.ToUpper()
            };

            var entity = await _corService.CreateAsync(cor);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Cor { Id = entity.Id, Nome = entity.Nome, Codigo = entity.Codigo });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Cor cor)
        {
            var entity = await _corService.UpdateAsync(cor.Id, cor);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Cor { Id = entity.Id, Nome = entity.Nome, Codigo = entity.Codigo });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _corService.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}