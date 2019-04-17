using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public interface IBaseService<TEntity>: IDisposable
    {
        int Add(TEntity entity);
        bool Delete(object id);
        bool Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        bool Update(TEntity entity);
        Task<PaginatedList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int page = 1, int pageSize = 10);
    }
}
