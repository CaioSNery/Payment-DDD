

using PaymentContext.Api.Extension;
using PaymentContext.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.AddConfigurationExtension();
builder.Services.AddHandlerExtension();
builder.Services.AddRepositoryExtension();

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

