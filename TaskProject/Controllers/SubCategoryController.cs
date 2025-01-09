using Microsoft.AspNetCore.Mvc;
using TaskProject.Domain.Category;
using TaskProject.Services.Category;

namespace TaskProject.Controllers
{
    [Route("SubCategory")]
    public class SubCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public SubCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            CatergoryFilter catergoryFilter = new CatergoryFilter()
            {
                PageIndex = 0,
                PageSize = 10,
            };
            return View(catergoryFilter);
        }

        [HttpPost("List")]
        public async Task<IActionResult> List(CatergoryFilter Filter)
        {
            try
            {
                return Json(await _categoryService.GetCategoriesPagedAsync(Filter));
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
