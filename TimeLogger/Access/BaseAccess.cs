using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLogger.Access
{
    public class BaseAccess<T> : IBaseAccess<T>
    {
        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> List()
        {
            throw new NotImplementedException();
        }

        public Task Remove(T t)
        {
            throw new NotImplementedException();
        }

        public async Task Save(T t)
        {
            // faking save, since there is no db
        }
    }
}
