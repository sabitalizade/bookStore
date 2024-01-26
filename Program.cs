using System.Text.Json.Serialization;
using BookStore;
using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Repository;
using Microsoft.EntityFrameworkCore;
using Bookshop.Repository;
using Bookshop.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<Seed>();
builder.Services.AddControllers();
// builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlite("Data Source=bookstore.db");
    // option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// generate lowercase URLs
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});

// app.UseHttpsRedirection();



// app.MapGet("/*", () =>
// {

//     return "Hello World!";
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();

