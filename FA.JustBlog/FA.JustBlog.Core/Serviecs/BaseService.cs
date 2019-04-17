using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;

        public BaseService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public int Add(TEntity entity)
        {
            return _genericRepository.Add(entity);
        }

        public bool Delete(object id)
        {
            if (id == null)
            {
                throw new Exception("ID null");
            }
            var entity = GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            return Delete(entity);
        }

        public bool Delete(TEntity entity)
        {
            return _genericRepository.Delete(entity);
        }

        public void Dispose()
        {
            _genericRepository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public async Task<PaginatedList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int page = 1, int pageSize = 10)
        {
            var query = _genericRepository.Get(filter: filter, includeProperties: includeProperties);
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await PaginatedList<TEntity>.CreateAsync(query.AsNoTracking(), page, pageSize);
        }

        public TEntity GetById(object id)
        {
            if (id == null)
            {
                throw new Exception("ID null");
            }
            return _genericRepository.GetById(id);
        }

        public bool Update(TEntity entity)
        {
            return _genericRepository.Update(entity);
        }
    }
}
