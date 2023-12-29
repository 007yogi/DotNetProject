using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStore.Domain.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task <int>Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
