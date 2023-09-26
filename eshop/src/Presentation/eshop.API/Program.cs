using eshop.API.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(option =>
                {
                    var factory = option.InvalidModelStateResponseFactory;
                    option.InvalidModelStateResponseFactory = context =>
                    {
                        var logger = context.HttpContext.RequestServices.GetService<ILogger<Program>>();
                        logger.LogInformation($"gönderilen http request, {context.ModelState.ErrorCount} adet hata var.");
                        logger.LogInformation($"Ayrıntılar: {string.Join(",", context.ModelState.Keys)}");
                        foreach (var item in context.ModelState.Values)
                        {
                            item.Errors.ToList().ForEach(e => logger.LogInformation($"Hata: {e.ErrorMessage}"));
                        }
                        return factory(context);

                    };
                });

builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,

                        ValidIssuer = "server.linktera",
                        ValidAudience = "client.linktera",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-ifade-tokeni-kanitlar"))

                    };
                });


//builder.Services.AddAuthentication()



//builder.Services.AddAutoMapper(typeof(MapProfile));

//builder.Services.AddScoped<IProductRepositoryAsync, EFProductRepository>();
//builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

//builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetAllProductRequestHandler).Assembly));
var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddInjectionsToIoC(connectionString);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
