var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependenciesConfiguration(builder.Configuration);

//builder.Services.AddScoped<IGenericRepository<Subject>, GenericRepository<Subject>>();
//builder.Services.AddScoped<IUnitOfWork<Subject>, UnitOfWork<Subject>>();
//builder.Services.AddScoped<IService<SubjectDTO>, SubjectService>();
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

//app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

app.MapControllers();

app.Run();