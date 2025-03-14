using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Infrastructure;
using Application;
using Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Registra repositórios na injeção de dependência
builder.Services.AddScoped<IProcessoSeletivo, ProcessoSeletivoRepository>();
builder.Services.AddScoped<IInscricao, InscricaoRepository>();
builder.Services.AddScoped<IOferta, OfertaRepository>();
builder.Services.AddScoped<ILead, LeadRepository>();

// Registra serviços da camada de aplicação
builder.Services.AddScoped<ProcessoSeletivoService>();
builder.Services.AddScoped<InscricaoService>();
builder.Services.AddScoped<OfertaService>();
builder.Services.AddScoped<LeadService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
