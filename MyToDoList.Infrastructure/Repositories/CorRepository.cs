using Microsoft.EntityFrameworkCore;
using MyToDoList.Domain.Entities;
using MyToDoList.Domain.Interfaces;
using MyToDoList.Infrastructure.Datas;

namespace MyToDoList.Infrastructure.Repositories
{
    public class CorRepository : ICorRepository
    {
        private readonly MyToDoListDbContext _context;
        public CorRepository(MyToDoListDbContext context)
        {
            _context = context;
        }

        private Cor GetCorById(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var entity = _context.Cores.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }
        public async Task<Cor> CreateAsync(Cor cor)
        {
            await _context.Cores.AddAsync(cor);

            _context.SaveChanges();
            return cor;
        }
        public bool Delete(int id)
        {
            var entity = GetCorById(id);

            if (entity == null)
            {
                return false;
            }

            _context.Cores.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<Cor> GetCompleteAsync(int id)
        {
            var entity = GetCorById(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<IEnumerable<Cor>> GetListAsync()
        {
            var entity = await _context.Cores.ToListAsync();

            return entity;
        }

        public async Task<Cor> UpdateAsync(int id, Cor cor)
        {
            var entity = GetCorById(id);

            if (entity == null)
            {
                return null;
            }

            entity.Nome = cor.Nome;
            entity.Codigo = cor.Codigo;

            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}