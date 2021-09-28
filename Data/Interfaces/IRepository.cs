using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
    }
}
