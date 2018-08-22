using System;
using System.Collections.Generic;

namespace JSONToDatabaseReader.Repository
{
    public interface IRepository<T>
    {
        T Get(int guid);
        void Save(T item);
        void Update(T item);
        void Delete(T item);
        List<T> GetAll();
    }
}
