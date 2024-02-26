using MyToDoList.Domain.Entities;

namespace MyToDoList.Application.Interfaces
{
    public interface ICorService
    {
        Task<IEnumerable<Cor>> GetListAsync();
        Task<Cor> GetCompleteAsync(int id);
        Task<Cor> CreateAsync(Cor cor);
        Task<Cor> UpdateAsync(int id, Cor cor);
        bool Delete(int id);
    }
}
