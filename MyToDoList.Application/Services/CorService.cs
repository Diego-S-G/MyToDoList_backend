using MyToDoList.Application.Interfaces;
using MyToDoList.Domain.Entities;
using MyToDoList.Domain.Interfaces;

namespace MyToDoList.Application.Services
{
    public class CorService : ICorService
    {
        private readonly ICorRepository _corRepository;
        public CorService(ICorRepository repository)
        {
            _corRepository = repository;
        }

        public Task<Cor> CreateAsync(Cor cor)
        {
            return _corRepository.CreateAsync(cor);
        }

        public bool Delete(int id)
        {
            return _corRepository.Delete(id);
        }

        public Task<Cor> GetCompleteAsync(int id)
        {
            return _corRepository.GetCompleteAsync(id);
        }

        public Task<IEnumerable<Cor>> GetListAsync()
        {
            return _corRepository.GetListAsync();
        }

        public Task<Cor> UpdateAsync(int id, Cor cor)
        {
            return _corRepository.UpdateAsync(id, cor);
        }
    }
}