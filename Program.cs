using MediatR;
using Microsoft.EntityFrameworkCore;
using ProximaEnergia.Entity;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Interfaces.Services;
using ProximaEnergia.Repositories;
using ProximaEnergia.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddScoped<IAgreementsService, AgreementsService>();
builder.Services.AddScoped<IAgreementsRepository, AgreementsRepository>();
builder.Services.AddScoped<IConsumptionRatesService, ConsumptionRatesService>();
builder.Services.AddScoped<IConsumptionRatesRepository, ConsumptionRatesRepository>();
builder.Services.AddScoped<IAgreementRatesService, AgreementRatesService>();
builder.Services.AddScoped<IAgreementRatesRepository, AgreementRatesRepository>();
builder.Services.AddScoped<ICommercialAgentsService, CommercialAgentsService>();
builder.Services.AddScoped<ICommercialAgentsRepository, CommercialAgentsRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
