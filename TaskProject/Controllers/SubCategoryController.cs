using Microsoft.AspNetCore.Mvc;
using TaskProject.Domain.Category;
using TaskProject.Domain.SubCategory;
using TaskProject.Services.Category;

namespace TaskProject.Controllers
{
    [Route("SubCategory")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subcategoryService;
        public SubCategoryController(ISubCategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            SubCatergoryFilter catergoryFilter = new SubCatergoryFilter()
            {
                CategoryID = 1,
                PageIndex = 0,
                PageSize = 10,
            };
            return View(catergoryFilter);
        }

        [HttpPost("List")]
        public async Task<IActionResult> List(SubCatergoryFilter Filter)
        {
            try
            {
                return Json(await _subcategoryService.GetSubCategoriesPagedAsync(Filter));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("CreateOrEdit/{id}")]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            CategoryViewModel model = new CategoryViewModel();

            // if (id.HasValue && id.Value > 0)
            //{
            //    model = await _approvalGroupRepository.GetByIdAsync(id.Value);
            //    if (model == null)
            //    {
            //        return NotFound();
            //    }

            //}
            return PartialView("_AddEditCategory", model);
        }

    }
}
