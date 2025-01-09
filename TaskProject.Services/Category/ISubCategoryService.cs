using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Domain.Pagging;
using TaskProject.Domain.SubCategory;
using TaskProject.Repositories.Dapper;

namespace TaskProject.Services.Category
{
    public interface ISubCategoryService
    {
        Task<PagedResult<SubCategoryViewListVM>> GetSubCategoriesPagedAsync(SubCatergoryFilter filter);
    }

    public class SubCategoryService : ISubCategoryService
    {
        private readonly IDapperRepository _dapperRepo;
        public SubCategoryService(IDapperRepository dapperRepository)
        {
            _dapperRepo = dapperRepository;
        }
        public async Task<PagedResult<SubCategoryViewListVM>> GetSubCategoriesPagedAsync(SubCatergoryFilter filter)
        {
            try
            {
                var parameters = new
                {
                    CategoryID = filter.CategoryID,
                    PageNumber = filter.PageIndex,
                    PageSize = filter.PageSize,
                    Search = filter.Search
                };
                var pagedResult = await _dapperRepo.GetPagedAsync<SubCategoryViewListVM>(
                    "SP_GetSubCategoryList",
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
