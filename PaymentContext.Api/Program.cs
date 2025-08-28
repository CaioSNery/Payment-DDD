using Microsoft.EntityFrameworkCore;
using PaymentContext.Domain.Command;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Repositories;
using PaymentContext.Infra.Data;
using PaymentContext.Infra.Repository;
using PaymentContext.Shared.Handlers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<SubscriptionHandler>();

builder.Services.AddScoped<IHandler<CreateBoletoSubscriptionCommand>, SubscriptionHandler>();

builder.Services.AddScoped<IHandler<CreatePaypalSubscriptionCommand>, SubscriptionHandler>();

builder.Services.AddScoped<IHandler<CreateCreditCardSubscriptionCommand>, SubscriptionHandler>();



builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();


app.MapControllers();




app.Run();

