using isolutionsFoodAssessment.WebApi.Data;
using isolutionsFoodAssessment.WebApi.Domain;
using isolutionsFoodAssessment.WebApi.RequestModels.FoodItem;
using isolutionsFoodAssessment.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace isolutionsFoodAssessment.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodItemsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FoodItem>))]
        public async Task<IEnumerable<FoodItem>> GetAll()
        {
            var foodList = await  _foodService.GetAll();

            return foodList;
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FoodItem))]
        public async Task<ActionResult<FoodItem>> Get(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }

            var foodItem = _foodService.GetOne(id);

            return Ok(foodItem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        public async Task<IActionResult> Insert(FoodItemCreateRequestModel createFoodItem)
        {
            //ToDo: Add automapper
            var foodItem = new FoodItem
            {
                Description = createFoodItem.Description,
                Calories = createFoodItem.Calories,
                ImageUrl = createFoodItem.ImageUrl
            };

            var addedFoodItem = await _foodService.AddAsync(foodItem);

            return CreatedAtAction(nameof(Get), new {id= addedFoodItem.Id}, addedFoodItem);
        }
    }
}