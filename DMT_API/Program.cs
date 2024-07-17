using DMT.Activity.DMTActivity;
using DMT.Contracts.DMT;
using DMT.Domain.Core.Interface;
using System.Reflection;
using DMTAPI.API.Extentions;
using DMT.Domain.DMT;
using DMT.ServiceIntegration.DMT;
using DMT.ServiceIntegration.DataContract;
using DMt.DataAccess;
using DMTAPI.API.Controllers.Login_Registration;
using DMt.DataAccess.LoginRegister;
using DMT.Domain.Login_Registration;
using DMT.Domain.Core.Helper;
using Microsoft.AspNetCore.Diagnostics;
using DMT.Activity.Login_Registration;



var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:3000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton(connectionString);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IActivity<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse>, QueryRimiterActivity>();
builder.Services.AddScoped<IServiceAdapterAsync<QueryRimitterServiceContractRequest, QueryRimitterServiceContractResponse>, QueriyRimitterAdapter>();
builder.Services.AddScoped<IDatabaseAdapter<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse>, SaveRemmiterAdapter>();
builder.Services.AddScoped<IActivity<LoginRegisterDomainRequest, LoginRegisterDomainResponse>, LoginRegisterActivity>();
builder.Services.AddScoped<IDatabaseAdapter<LoginRegisterDomainRequest, LoginRegisterDomainResponse>, LoginRegisterAdapter>();
builder.Services.AddScoped<IActivity<LoginDomainRequest, LoginDomainResponse>, LoginActivity>();
builder.Services.AddScoped<IDatabaseAdapter<LoginDomainRequest, LoginDomainResponse>, LoginAdapter>();


//builder.Services.AddScopedIActivity<LoginDomainRequest, LoginDomainResponse>, LoginRegisterAdapter>();
//builder.Services.AddTransient<IConnectionRetreiver, ConnectionRetreiver>();



var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
app.UseSwaggerUI();
}

//app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();


//app.UseEndpoints(endpoints =>
//{

//    endpoints.MapControllers();
//});

app.MapControllers();

app.Run();
