namespace FA.JustBlog.Core.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IGenericRepository<Category> genericRepository) : base(genericRepository)
        {
        }
    }
}
