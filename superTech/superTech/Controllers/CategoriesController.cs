using Microsoft.AspNetCore.Mvc;
using superTech.Models.Category;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseCRUDController<CategoryModel, object, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        public CategoriesController(ICRUDService<CategoryModel, object, CategoryUpsertRequest, CategoryUpsertRequest> IBaseService) : base(IBaseService)
        {

        }
    }
}