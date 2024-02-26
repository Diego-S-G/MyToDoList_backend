using MyToDoList.Domain.Entities;

namespace MyToDoList.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetListAsync();
        Task<Tarefa> GetCompleteAsync(int id);
        Task<Tarefa> CreateAsync(Tarefa tarefa);
        Task<Tarefa> UpdateAsync(int id, Tarefa tarefa);
        bool Delete(int id);
    }
}
