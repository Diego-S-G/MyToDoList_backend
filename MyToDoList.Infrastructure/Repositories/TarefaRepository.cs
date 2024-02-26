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

        public async Task<IEnumerable<Tarefa>> GetListAsync()
        {
            var entity = await _context.Tarefas.ToListAsync();

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
    }
}
