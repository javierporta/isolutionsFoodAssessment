using FluentValidation;

namespace isolutionsFoodAssessment.WebApi.RequestModels.FoodItem
{
    public class FoodItemCreateRequestModel
    {
        public string Description { get; set; } = string.Empty;
        public decimal Calories { get; set; } = 0;
        public string ImageUrl { get; set; } = string.Empty;
    }

    public class FoodItemCreateRequestModelValidator : AbstractValidator<FoodItemCreateRequestModel>
    {
        public FoodItemCreateRequestModelValidator()
        {
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description is null or empty").MinimumLength(15);
            RuleFor(x => x.Calories).NotEmpty().NotNull().WithMessage("A meal with no calories? I want that!").GreaterThan(0);
        }
    }

    
}
