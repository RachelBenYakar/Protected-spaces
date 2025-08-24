using Core.IRepositories_Data;
using Core.IServices_Bll;
using Core.Mapping;
using Microsoft.EntityFrameworkCore;
using Repositories_Data;
using Repositories_Data.Data;
using Services_Bll;



var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddDbContext<WarContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DB")
     , x =>
     {
         x.MigrationsAssembly("Repositories_Data"); x.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
         x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
     });
    /*  options.UseLoggerFactory(LoggerFactory.Create(builder =>
      {
        *  builder.AddDebug();
      }));*/
    options.EnableSensitiveDataLogging();
});


builder.Services.AddAutoMapper(typeof(MappingProfile));

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
