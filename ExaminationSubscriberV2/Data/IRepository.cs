using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSubscriberV2.Data
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> Get(T entity);
        Task<T> Get(int id);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
