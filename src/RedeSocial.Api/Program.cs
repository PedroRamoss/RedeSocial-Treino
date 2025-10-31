using RedeSocial.Api.DependencyModules;
using RedeSocial.Application;
using RedeSocial.Application.Dispatcher;
using RedeSocial.Application.EventHandlers;
using RedeSocial.Application.Services;
using RedeSocial.Application.Services.Interfaces;
using RedeSocial.Database;
using RedeSocial.Domain.Events;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddAuthenticationApiDependency(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfigurationDependency();
builder.Services.AddRepositoriesDependency();
builder.Services.AddApplicationDependency();

builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
builder.Services.AddScoped<IDomainEventHandler<UserCreatedEvent>, SendWelcomeEmailHandler>();
builder.Services.AddScoped<IEmailService, EmailService>();

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
