using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using isolutionsFoodAssessment.WebApi.Controllers;
using isolutionsFoodAssessment.WebApi.Domain;
using isolutionsFoodAssessment.WebApi.RequestModels.FoodItem;
using isolutionsFoodAssessment.WebApi.Services;
using Xunit;

namespace isolutionsFoodAssessment.WebApi.Tests.Controllers
{
    public class FoodItemsControllerShould
    {
        private FoodItemsController _foodItemsController;
        private IFoodService _foodService;

        public FoodItemsControllerShould()
        {
            _foodService = A.Fake<IFoodService>();
            _foodItemsController = new FoodItemsController(_foodService);
        }

        [Fact]
        public async Task InsertShouldCallAddService()
        {
            var objecToAdd = new FoodItem()
            {
                Calories = 125,
                Description = "asdasdasdasd",
                ImageUrl = "www.test.com"
            };

            A.CallTo(() => _foodService.AddAsync(A<FoodItem>.Ignored)).Returns(objecToAdd);

            var request = new FoodItemCreateRequestModel()
            {
                Calories = 125,
                Description = "asdasdasdasd",
                ImageUrl = "www.test.com"
            };

            await _foodItemsController.Insert(request);

            A.CallTo(() => _foodService.AddAsync(A<FoodItem>.That.Matches(x=>x.Calories== objecToAdd.Calories && x.Description == objecToAdd.Description && x.ImageUrl == objecToAdd.ImageUrl))).MustHaveHappenedOnceExactly();
        }
    }
}
