namespace FA.JustBlog.Core
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IGenericRepository<Category> genericRepository) : base(genericRepository)
        {
        }
    }
}
