namespace isolutionsFoodAssessment.WebApi.Domain
{
    public class FoodItem
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
