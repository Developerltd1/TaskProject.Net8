using TaskProject.Domain.Category;
using TaskProject.Domain.Pagging;
using TaskProject.Repositories.Dapper;

namespace TaskProject.Services.Category
{
    public interface ICategoryService
    {
        //Task<int> CreateAsync(CategoryViewModel categoryVM);
        // Task<CategoryViewModel> GetByIdAsync(int categoryId);
        Task<PagedResult<CategoryViewListVM>> GetCategoriesPagedAsync(CatergoryFilter filter);
    }
    public class CategoryService : ICategoryService
    {
        private readonly IDapperRepository _dapperRepo;
        public CategoryService(IDapperRepository dapperRepository)
        {
            _dapperRepo = dapperRepository;
        }
        public async Task<PagedResult<CategoryViewListVM>> GetCategoriesPagedAsync(CatergoryFilter filter)
        {
            try
            {

           
            var parameters = new
            {
                PageNumber = filter.PageIndex,
                PageSize = filter.PageSize,
                Search = filter.Search
            };
            var pagedResult = await _dapperRepo.GetPagedAsync<CategoryViewListVM>(
                "SP_GetCategoryList", 
                parameters
            );
            return pagedResult;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }


}

