using DMT.Activity.DMTActivity;
using DMT.Contracts.DMT;
using DMT.Domain.Core.Interface;
using System.Reflection;
using DMTAPI.API.Extentions;
using DMT.Domain.DMT;
using DMT.ServiceIntegration.DMT;
using DMT.ServiceIntegration.DataContract;
using DMt.DataAccess;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IActivity<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse>, QueryRimiterActivity>();
builder.Services.AddScoped<IServiceAdapterAsync<QueryRimitterServiceContractRequest, QueryRimitterServiceContractResponse>, QueriyRimitterAdapter>();
builder.Services.AddScoped<IDatabaseAdapter<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse>, SaveRemmiterAdapter>();


var app = builder.Build();

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
