using Microsoft.EntityFrameworkCore;
using MunicipalityProject.Contexts;
using MunicipalityProject.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddTransient<IMunicipalityService, MunicipalityService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

app.UseRouting();
app.UsePathBase("/api");
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();
});

app.Run();
