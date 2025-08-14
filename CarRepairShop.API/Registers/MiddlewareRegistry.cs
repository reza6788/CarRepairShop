using CarRepairShop.API.Filters;

namespace CarRepairShop.API.Registers;

public static class MiddlewareRegistry
{
    public static void ConfigureMiddlewares(this WebApplication app)
    {
        app.UseHttpsRedirection();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolProvider API V1");
                options.RoutePrefix = "swagger"; // swagger UI at /swagger
            });
        }

        app.MapControllers();

        app.MapGet("/",
            context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            }).AllowAnonymous();

        // Error handler middleware
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}