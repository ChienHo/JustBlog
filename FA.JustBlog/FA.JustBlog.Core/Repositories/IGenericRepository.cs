using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public interface IGenericRepository<TEntity> : IDisposable
    {
        int Add(TEntity entity);
        bool Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        bool Update(TEntity entity);
    }
}
