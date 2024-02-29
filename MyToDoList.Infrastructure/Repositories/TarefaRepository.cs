using Microsoft.EntityFrameworkCore;
using MyToDoList.Domain.Entities;
using MyToDoList.Domain.Interfaces;
using MyToDoList.Infrastructure.Datas;

namespace MyToDoList.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly MyToDoListDbContext _context;
        public TarefaRepository(MyToDoListDbContext context)
        {
            _context = context;
        }

        private Tarefa GetTarefaById(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var entity = _context.Tarefas.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }
        public async Task<Tarefa> CreateAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);

            _context.SaveChanges();
            return tarefa;
        }
        public bool Delete(int id)
        {
            var entity = GetTarefaById(id);

            if (entity == null)
            {
                return false;
            }

            _context.Tarefas.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<Tarefa> GetCompleteAsync(int id)
        {
            var entity = GetTarefaById(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<IEnumerable<Tarefa>> GetNotFinished()
        {
            var entity = await _context.Tarefas
                .Where(x => x.Finalizado == false)
                .ToListAsync();

            return entity;
        }

        public async Task<IEnumerable<Tarefa>> GetFinished()
        {
            var entity = await _context.Tarefas
                .Where(x => x.Finalizado == true)
                .ToListAsync();

            return entity;
        }
        public async Task<Tarefa> UpdateAsync(int id, Tarefa tarefa)
        {
            var entity = GetTarefaById(id);

            if (entity == null)
            {
                return null;
            }

            entity.Descricao = tarefa.Descricao;
            entity.Finalizado = tarefa.Finalizado;

            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool DeleteAll()
        {
            var entities = GetFinished();

            if (entities == null)
            {
                return false;
            }

            _context.Tarefas.RemoveRange(entities.Result);
            _context.SaveChanges();
            return true;
        }
    }
}