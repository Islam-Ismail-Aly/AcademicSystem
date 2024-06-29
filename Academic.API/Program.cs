var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependenciesConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        //    options.InjectStylesheet("/swagger-ui/custom.css");
        options.SwaggerEndpoint("/swagger/AcademicSystemAPIv1/swagger.json", "AcademicSystemAPI");

    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

app.MapControllers();

app.Run();