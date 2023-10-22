using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLogger.Access
{
    public interface IBaseAccess<T>
    {
        public Task Save(T t);
        public Task<T> GetById(int id);
        public Task<List<T>> List();
        public Task Remove(T t);
    }
}
