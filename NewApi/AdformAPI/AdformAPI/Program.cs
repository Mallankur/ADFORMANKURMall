using AdformAPI.Data;
using AdformAPI.Entites;
using AdformAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ConfiurationwithDatabase>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IAdformContext, AdformContextcs>();
builder.Services.AddScoped<IProductRepository, ProductRipositorycs>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
