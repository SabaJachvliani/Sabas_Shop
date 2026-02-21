using Application.Common.Behaviors;
using Application.Markers;
using Application.Interfaces.Infrastructure;
using Asp.Versioning;
using Asp.Versioning.Routing;
using FluentValidation;
using Infrastucture.SabaShopDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MediatR (Application assembly)
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));

// FluentValidation (Application assembly)
builder.Services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);

// Validation pipeline (runs validators automatically before handlers)
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient<Sabas_Shop.Middlewares.ValidationExceptionMiddleware>();


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SabaShopDb>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ISabaShopDb, SabaShopDb>();

builder.Services.AddApiVersioning(o =>
{
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.ReportApiVersions = true;
})
.AddApiExplorer(o =>
{
    o.GroupNameFormat = "'v'VVV";
    o.SubstituteApiVersionInUrl = true;
});

builder.Services.Configure<RouteOptions>(o =>
{
    o.ConstraintMap["apiVersion"] = typeof(ApiVersionRouteConstraint);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseMiddleware<Sabas_Shop.Middlewares.ValidationExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();