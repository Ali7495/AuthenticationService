using FluentMigrator.Runner;
using UserManagerApi.Infrastructure.Migrations;
using UserManagerApi.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(runner => runner

        .AddPostgres()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("usermanagerDb"))
        .ScanIn(typeof(Create_Person_Table).Assembly).For.Migrations()

    ).AddLogging(logging => logging.AddFluentMigratorConsole());

DependencyContainer.RegisterServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    migrator.MigrateUp();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
