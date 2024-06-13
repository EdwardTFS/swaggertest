namespace swaggertest;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        //builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApiDocument();

        var app = builder.Build();

        app.UseOpenApi();
        app.UseSwaggerUi();



        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
                await context.Response.WriteAsync(@$"<html><body><h1>Swagger Test</h1><a href=""swagger"">swagger</a></body></html>"));
        });
        app.MapControllers();

        app.Run();
    }
}
