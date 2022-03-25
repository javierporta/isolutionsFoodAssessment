using isolutionsFoodAssessment.WebApi.Domain;

namespace isolutionsFoodAssessment.WebApi.Services
{
    public interface IFoodService
    {
        public Task<FoodItem> AddAsync(FoodItem foodItem);
        public Task<IEnumerable<FoodItem>> GetAll();
        public Task<FoodItem?> GetOne(Guid id);
    }
}
