using Microsoft.EntityFrameworkCore;
using DataLayer;
using ServiceLayer.Managers;
using ServiceLayer.Services;
using ServiceLayer.Managers.Interface;
using ServiceLayer.Services.Interface;
using ServiceLayer.Mapping;
using AutoMapper;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EmployeeEFDBcontext>(options => options.UseSqlServer(con, b => b.MigrationsAssembly("DataLayer")));

// Mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Repositories
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IChildRepository, ChildRepository>();
builder.Services.AddTransient<IPositionRepository, PositionRepository>();


// Services
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IChildService, ChildService>();
builder.Services.AddTransient<IPositionService, PositionService>();


// Managers
builder.Services.AddScoped<IServicesManager, ServicesManager>();
builder.Services.AddScoped<IDataManager, DataManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EmployeeEFDBcontext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
