﻿using MyToDoList.Domain.Entities;

namespace MyToDoList.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetListAsync();
        Task<Tarefa> GetCompleteAsync(int id);
        Task<Tarefa> CreateAsync(Tarefa tarefa);
        Task<Tarefa> UpdateAsync(int id, Tarefa tarefa);
        bool Delete(int id);
    }
}
