using isolutionsFoodAssessment.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace isolutionsFoodAssessment.WebApi.Data
{
    public class AssessmentDbContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }

        public AssessmentDbContext(DbContextOptions<AssessmentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodItem>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<FoodItem>()
                .Property(e => e.Description)
                .IsRequired();
        }
    }
}
