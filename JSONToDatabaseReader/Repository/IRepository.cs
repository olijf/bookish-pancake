using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONToDatabaseReader.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        void Save(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
        IQueryable<T> GetQueryable();
        List<T> GetAll();
    }
}
