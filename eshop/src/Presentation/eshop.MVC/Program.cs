using eshop.Application;
using eshop.Application.Handlers;
using eshop.Application.Mappings;
using eshop.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepositoryAsync, FakeProductRepository>();
//builder.Services.AddScoped<GetAllProductRequestHandler>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetAllProductRequestHandler).Assembly));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

