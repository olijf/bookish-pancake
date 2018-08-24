using System;
using NHibernate;
using System.Linq;
using System.Collections.Generic;

namespace JSONToDatabaseReader.Repository
{
    public class NHibernateRepository<T> : IRepository<T> where T : class
    {
        ISession session = NHibernateHelper.Session;

        public void Save(T item)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(item);
                transaction.Commit();
            }
        }

        public T Get(int id)
        {
            return session.Get<T>(id);
        }

        public void Update(T item)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(item);
                transaction.Commit();
            }
        }
        
        public List<T> GetAll()
        {
            return session.Query<T>().ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return session.Query<T>();
        }

        public void Delete(int id)
        {
            Delete(Get(id));
        }

        public void Delete(T item)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(item);
                transaction.Commit();
            }
        }
    }
}