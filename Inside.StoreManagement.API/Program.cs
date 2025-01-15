using Inside.StoreManagement.API;
using Inside.StoreManagement.API.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Bootstrap bootstrap = new();
bootstrap.ConfigureServices(builder.Services, builder.Configuration);

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store Management");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();