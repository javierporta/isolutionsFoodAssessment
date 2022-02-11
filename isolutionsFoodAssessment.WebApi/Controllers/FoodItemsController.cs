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
        private readonly AssessmentDbContext assessmentDbContext;

        public FoodItemsController(AssessmentDbContext assessmentDbContext)
        {
            this.assessmentDbContext = assessmentDbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FoodItem>))]
        public async Task<IActionResult> Get()
        {
            var foodList = await assessmentDbContext.FoodItems.ToListAsync();

            return Ok(foodList);
        }

        
    }
}