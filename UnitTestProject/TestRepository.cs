using JSONToDatabaseReader.Datamodel;
using JSONToDatabaseReader.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JSONToDatabaseReaderTestProject
{
    public class TestRepository<T> : IRepository<T> where T : class, IRepositoryObject
    {
        private List<T> _items = new List<T>();

        public void Delete(T item)
        {
            Debug.Assert(_items.Contains(item));
            _items.Remove(item);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item != null)
                Delete(item);
        }

        public T Get(int id)
        {
            return _items.Find(g => g.Id == id);
        }

        public List<T> GetAll()
        {
            return new List<T>(_items);
        }

        public IQueryable<T> GetQueryable()
        {
            return _items.AsQueryable();
        }

        public void Save(T item)
        {
            _items.Add(item);
        }

        public void Update(T item)
        {
            Delete(item);
            Save(item);
        }
    }
}