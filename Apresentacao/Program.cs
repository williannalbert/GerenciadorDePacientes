using Aplicacao.Interfaces;
using Aplicacao.Mapeamentos;
using Aplicacao.Servicos;
using Apresentacao.Middleware;
using Apresentacao.Seeders;
using Dominio.Interfaces;
using Infraestrutura.Dados;
using Infraestrutura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

#region MySql configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));
#endregion

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddScoped<IConvenioService, ConvenioService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();

builder.Services.AddScoped<IConvenioRepository, ConvenioRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(ConvenioProfile));
builder.Services.AddAutoMapper(typeof(PacienteProfile));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await ConvenioSeeder.SeedAsync(services);
    await PacienteSeeder.SeedAsync(services);

}
app.UseHttpsRedirection();

app.UseMiddleware<ErrorMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
