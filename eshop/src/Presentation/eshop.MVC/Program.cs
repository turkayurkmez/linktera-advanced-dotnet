using eshop.Application.Handlers;
using eshop.Application.Mappings;
using eshop.Data.Context;
using eshop.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MapProfile));
//builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepositoryAsync, EFProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
//builder.Services.AddScoped<GetAllProductRequestHandler>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetAllProductRequestHandler).Assembly));

var connectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddDbContext<EshopDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Users/Login";

                    option.ReturnUrlParameter = "gidilecekSayfa";
                });

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

