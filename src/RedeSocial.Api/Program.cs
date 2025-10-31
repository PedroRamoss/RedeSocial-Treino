using RedeSocial.Api.DependencyModules;
using RedeSocial.Application;
using RedeSocial.Database;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddAuthenticationApiDependency(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfigurationDependency();
builder.Services.AddRepositoriesDependency();
builder.Services.AddApplicationDependency();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
