using Microsoft.EntityFrameworkCore;
using MyToDoList.Domain.Entities;

namespace MyToDoList.Infrastructure.Datas
{
    public class MyToDoListDbContext : DbContext
    {
        public MyToDoListDbContext(DbContextOptions<MyToDoListDbContext> options) : base(options) { }
        public virtual DbSet<Tarefa> Tarefas { get; set; }
        public virtual DbSet<Cor> Cores { get; set; }
    }
}
