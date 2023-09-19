using creatingMiddlewares.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("<<<----");
//    await next();
//    await context.Response.WriteAsync("---->>>");
//});


//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("........");
//    await next();
//    await context.Response.WriteAsync("........");
//});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseMiddleware<JSONBodyMiddleware>();
//app.UseMiddleware<BadwordsHandlerMiddleware>();
app.UseBadwordsHandler();

app.UseAuthorization();

app.MapControllers();
//app.Run(async context => await context.Response.WriteAsync("App is working"));

app.Run();
