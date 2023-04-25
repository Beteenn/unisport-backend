using IoC;
using IoC.Configuration;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
	.SetBasePath(builder.Environment.ContentRootPath)
	.AddJsonFile("appsettings.json", true, true)
	.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
	.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers(options =>
{
	options.Conventions.Add(new RouteTokenTransformerConvention(new LowerCaseParameterTransformer()));
	options.Filters.Add(new ExceptionHandlerActionFilter());
}).AddJsonOptions(options =>
{
	options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	options.JsonSerializerOptions.WriteIndented = true;
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
	options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
})
.AddNewtonsoftJson(options =>
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Setting DBContexts
builder.Services.ConfigureEF(builder.Configuration.GetConnectionString("connection"));

// Setting Identity
builder.Services.ConfigureIdentityAuthentication();

// Setting Dependencies
builder.Services.ConfigureDependencies(builder.Configuration);

// Swagger Config
builder.Services.AddSwaggerConfiguration(builder.Environment.EnvironmentName);

// Setting CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy",
		builder => builder.SetIsOriginAllowed((host) => true)
		.AllowAnyMethod()
		.AllowAnyHeader()
		.AllowCredentials()
		.WithExposedHeaders("Content-Disposition"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseSwagger().UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("v1/swagger.json", "IdentityServer API v1");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
