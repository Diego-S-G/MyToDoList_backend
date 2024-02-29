using MyToDoList.Application.Interfaces;
using MyToDoList.Domain.Entities;
using MyToDoList.Domain.Interfaces;

namespace MyToDoList.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(ITarefaRepository repository)
        {
            _tarefaRepository = repository;
        }

        public Task<Tarefa> CreateAsync(Tarefa tarefa)
        {
            return _tarefaRepository.CreateAsync(tarefa);
        }

        public bool Delete(int id)
        {
            return _tarefaRepository.Delete(id);
        }

        public Task<Tarefa> GetCompleteAsync(int id)
        {
            return _tarefaRepository.GetCompleteAsync(id);
        }

        public Task<IEnumerable<Tarefa>> GetNotFinished()
        {
            return _tarefaRepository.GetNotFinished();
        }

        public Task<IEnumerable<Tarefa>> GetFinished()
        {
            return _tarefaRepository.GetFinished();
        }

        public Task<Tarefa> UpdateAsync(int id, Tarefa tarefa)
        {
            return _tarefaRepository.UpdateAsync(id, tarefa);
        }

        public bool DeleteAll()
        {
            return _tarefaRepository.DeleteAll();
        }
    }
}