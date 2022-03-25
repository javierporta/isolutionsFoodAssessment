using isolutionsFoodAssessment.WebApi.Data;
using isolutionsFoodAssessment.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using FluentValidation;
using FluentValidation.AspNetCore;
using isolutionsFoodAssessment.WebApi.RequestModels.FoodItem;
using isolutionsFoodAssessment.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AssessmentDbContext>(opts => opts.UseInMemoryDatabase("isolutionsFoodAssesment"));
builder.Services.AddFluentValidation();

builder.Services.AddTransient<IFoodService, FoodService>();
builder.Services.AddTransient<IValidator<FoodItemCreateRequestModel>, FoodItemCreateRequestModelValidator>();

var app = builder.Build();

// Insert mocked data to the In Memory database
var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AssessmentDbContext>();
var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
var mockedDataFilePath = Path.Combine(baseDirectory, "Data", "FoodMockedData.json");
var mockedDataFileContent = File.ReadAllText(mockedDataFilePath);
var foodItems = JsonSerializer.Deserialize<FoodItem[]>(mockedDataFileContent, new JsonSerializerOptions(JsonSerializerDefaults.Web));
dbContext.AddRange(foodItems);
dbContext.SaveChanges();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(configure => configure.AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
