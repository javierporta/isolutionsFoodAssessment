using isolutionsFoodAssessment.WebApi.Data;
using isolutionsFoodAssessment.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace isolutionsFoodAssessment.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodItemsController : ControllerBase
    {
        private readonly AssessmentDbContext _assessmentDbContext;

        public FoodItemsController(AssessmentDbContext assessmentDbContext)
        {
            _assessmentDbContext = assessmentDbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FoodItem>))]
        public async Task<IActionResult> Get()
        {
            var foodList = await _assessmentDbContext.FoodItems.ToListAsync();

            return Ok(foodList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(FoodItem))]
        public async Task<IActionResult> Insert(object createFoodItem)
        {
            // ToDo: To be implemented by you
            throw new NotImplementedException();
        }
    }
}