using api.techsunolved.com.Repository.BaseRepository.Class;
using api.techunsolved.com.Configurations.MapperConfig;
using api.techunsolved.com.Repository.BaseRepository.Interface;
using api.techunsolved.com.Repository.TechArticleRepository.Class;
using api.techunsolved.com.Repository.TechArticleRepository.Interface;
using api.techunsolved.com.Repository.TechArticlesDataRepository.Class;
using api.techunsolved.com.Repository.TechArticlesDataRepository.Interface;
using api.techunsolved.com.Repository.TechCategoryRepository.Class;
using api.techunsolved.com.Repository.TechCategoryRepository.Interface;
using api.techunsolved.com.Repository.TechModuleRepository.Class;
using api.techunsolved.com.Repository.TechModuleRepository.Interface;
using api.techunsolved.com.Repository.TechSubCategoryRepository.Class;
using api.techunsolved.com.Repository.TechSubCategoryRepository.Interface;
using api.techunsolved.com.Repository.TechTopicRepository.Class;
using api.techunsolved.com.Repository.TechTopicRepository.Interface;
using api.techunsolved.com.Services;
using api.techunsolved.com.TechContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddScoped<ITechCategoryRepository, TechCategoryRepository>();
builder.Services.AddScoped<ITechSubCategoryRepository, TechSubCategoryRepository>();
builder.Services.AddScoped<ITechModuleRepository, TechModuleRepository>();
builder.Services.AddScoped<ITechTopicRepository, TechTopicRepository>();
builder.Services.AddScoped<ITechArticleRepository, TechArticleRepository>();
builder.Services.AddScoped<ITechArticlesDataRepository, TechArticlesDataRepository>();
builder.Services.AddTransient<IDateTimeService, DateTimeService>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("codeConnectionString"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("RvdCorsOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000",
                            "https://code.techunsolved.com",
                            "http://192.168.43.21:3000",
                            "https://admin.techunsolved.com")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("RvdCorsOrigins");

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<DataContext>();
if (db.Database.GetPendingMigrations().Any())
{
    db.Database.Migrate();
}

app.Run();
