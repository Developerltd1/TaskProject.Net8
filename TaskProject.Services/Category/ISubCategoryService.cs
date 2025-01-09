using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Domain.Category;
using TaskProject.Domain.Pagging;
using TaskProject.Repositories.Dapper;

namespace TaskProject.Services.Category
{
    public interface ISubCategoryService
    {
        Task<PagedResult<CategoryViewListVM>> GetSubCategoriesPagedAsync(CatergoryFilter filter);
    }

    public class SubCategoryService : ISubCategoryService
    {
        private readonly IDapperRepository _dapperRepo;
        public SubCategoryService(IDapperRepository dapperRepository)
        {
            _dapperRepo = dapperRepository;
        }
        public async Task<PagedResult<CategoryViewListVM>> GetSubCategoriesPagedAsync(CatergoryFilter filter)
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
