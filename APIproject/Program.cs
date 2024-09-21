using Application.Interfaces;
using Application.Mapper;
using Application.UseCases;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Marketing CRM",
        Version = "v1",
    });
}));

//Dependency Injectios Db context y conexion a base de datos
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));

//Dependency Injections Services
builder.Services.AddScoped<ICampaignTypeServices, CampaignTypeServices>();
builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddScoped<IInteractionTypesServices, InteractionTypesServices>();
builder.Services.AddScoped<ITaskStatusServices, TaskStatusServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IProjectServices, ProjectServices>();
builder.Services.AddScoped<IInteractionsService, InteractionsService>();
builder.Services.AddScoped<ITasksService, TasksService>();

//Dependency Injections Commands
builder.Services.AddScoped<IClientCommand, ClientCommand>();
builder.Services.AddScoped<IProjectCommand, ProjectCommand>();
builder.Services.AddScoped<IInteractionsCommand, InteractionsCommand>();
builder.Services.AddScoped<ITasksCommand, TasksCommand>();

//Dependency Injections Querys
builder.Services.AddScoped<ICampaignTypeQuery, CampaignTypeQuery>();
builder.Services.AddScoped<IClientQuery, ClientQuery>();
builder.Services.AddScoped<IInteractionTypesQuery, InteractionTypesQuery>();
builder.Services.AddScoped<ITaskStatusQuery, TaskStatusQuery>();
builder.Services.AddScoped<IUserQuery, UserQuery>();
builder.Services.AddScoped<IProjectQuery, ProjectQuery>();
builder.Services.AddScoped<IInteractionsQuery, InteractionsQuery>();
builder.Services.AddScoped<ITasksQuery, TasksQuery>();

//Dependency Injections Mappers
builder.Services.AddScoped<ICampaignTypeMapper, CampaignTypeMapper>();
builder.Services.AddScoped<IClientMapper, ClientMapper>();
builder.Services.AddScoped<IInteractionTypesMapper, InteractionTypesMapper>();
builder.Services.AddScoped<ITaskStatusMapper, TaskStatusMapper>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IProjectDataMapper, ProjectDataMapper>();
builder.Services.AddScoped<IInteracionsMapper, InteracionsMapper>();
builder.Services.AddScoped<ITasksMapper, TasksMapper>();
builder.Services.AddScoped<IProjectMapper, ProjectMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marketing CRM v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

