using MyToDoList.Domain.Entities;

namespace MyToDoList.Domain.Interfaces
{
    public interface ICorRepository
    {
        Task<IEnumerable<Cor>> GetListAsync();
        Task<Cor> GetCompleteAsync(int id);
        Task<Cor> CreateAsync(Cor cor);
        Task<Cor> UpdateAsync(int id, Cor cor);
        bool Delete(int id);
    }
}
