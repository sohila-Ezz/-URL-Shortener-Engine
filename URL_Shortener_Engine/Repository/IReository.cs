using System.Collections.Generic;
using System.Threading.Tasks;

namespace URL_Shortener_Engine.Repository
{
    public interface IReository<T, T1>
    {
        Task<IEnumerable<T>> GetAll();
        T Delete(T1 id);
        Task<T> GetById(T1 id);
        Task<T> Insert(T item);
        T Update(T1 id, T item);
    }
}
