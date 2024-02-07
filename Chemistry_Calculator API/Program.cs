using Microsoft.EntityFrameworkCore;
using Infrastructure;
using ChemLib.Contracts;
using ChemLib.Services;
using Infrastructure.Repo;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SciDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddScoped<IMolecular, Molecular_Service>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



var app = builder.Build();

//TODO: Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<SciDbContext>();
    dbContext.Database.EnsureCreated();
    dbContext.Database.Migrate();

   await dbContext.SeedDataAsync(services);
}


app.UseAuthorization();

app.MapControllers();

app.Run();
