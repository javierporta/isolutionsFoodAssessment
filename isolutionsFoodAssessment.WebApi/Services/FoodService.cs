using System.Collections.Immutable;
using isolutionsFoodAssessment.WebApi.Data;
using isolutionsFoodAssessment.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace isolutionsFoodAssessment.WebApi.Services
{
    public class FoodService : IFoodService
    {
        private readonly AssessmentDbContext _assessmentDbContext;
        public FoodService(AssessmentDbContext assessmentDbContext)
        {
            _assessmentDbContext = assessmentDbContext;
        }
        public async Task<FoodItem> AddAsync(FoodItem foodItem)
        {
            var addedEntity = await _assessmentDbContext.FoodItems.AddAsync(foodItem);
            await CommitOperationAsync();
            return addedEntity.Entity;
        }

        public async Task<IEnumerable<FoodItem>> GetAll()
        {
            return await _assessmentDbContext.FoodItems.ToListAsync();
        }

        public async Task<FoodItem?> GetOne(Guid id)
        {
            return await _assessmentDbContext.FoodItems.FindAsync(id);
        }

        private Task CommitOperationAsync()
        {
            return _assessmentDbContext.SaveChangesAsync();
        }
    }
}
