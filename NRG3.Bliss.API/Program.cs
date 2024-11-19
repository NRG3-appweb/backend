using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.AppointmentManagement.Application.ACL.Services;
using NRG3.Bliss.API.AppointmentManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.AppointmentManagement.Application.Internal.QueryServices;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.AppointmentManagement.Infrastructure.Persistence.EFC.Repositories;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.ACL;
using NRG3.Bliss.API.IAM.Application.ACL;
using NRG3.Bliss.API.IAM.Application.Internal.QueryServices;
using NRG3.Bliss.API.IAM.Domain.Repositories;
using NRG3.Bliss.API.IAM.Domain.Services;
using NRG3.Bliss.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using NRG3.Bliss.API.IAM.Interfaces.ACL;
using NRG3.Bliss.API.ReviewManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.ReviewManagement.Application.Internal.QueryServices;
using NRG3.Bliss.API.ReviewManagement.Domain.Repositories;
using NRG3.Bliss.API.ReviewManagement.Domain.Services;
using NRG3.Bliss.API.ReviewManagement.Infrastructure.Persistence.EFC.Repositories;
using NRG3.Bliss.API.ServiceManagement.Application.ACL;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.QueryServices;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.ServiceManagement.Infrastructure.Persistence.EFC.Repositories;
using NRG3.Bliss.API.ServiceManagement.Interfaces.ACL;
using NRG3.Bliss.API.Shared.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Apply Route Naming Convention

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins("*")
                .WithMethods("POST", "GET", "PUT", "DELETE")
                .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Connection string is null.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString);
});

// OpenAPI/Swagger Configuration
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Dependency Injection Configuration

// Shared Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Service Management Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceCommandService, ServiceCommandService>();
builder.Services.AddScoped<IServiceQueryService, ServiceQueryService>();
builder.Services.AddScoped<IServiceContextFacade, ServiceContextFacade>(); //new

builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();
builder.Services.AddScoped<ICompanyCommandService, CompanyCommandService>();
builder.Services.AddScoped<ICompanyQueryService, CompanyQueryService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();
builder.Services.AddScoped<IAppointmentQueryService, AppointmentQueryService>();
builder.Services.AddScoped<IAppointmentContextFacade, AppointmentContextFacade>();

builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IIAMContextFacade, IAMContextFacade>();

builder.Services.AddScoped<IUserRepository, UserRepository>();


// Review Management Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();

var app = builder.Build();

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// Use CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();