using System.Collections.Immutable;
using LibraryManagment.Api.Brokers.DateTime;
using LibraryManagment.Api.Brokers.Storages;
using LibraryManagment.Api.Services.Foundations.Baskets;
using LibraryManagment.Api.Services.Foundations.Books;
using LibraryManagment.Api.Services.Foundations.Rents;
using LibraryManagment.Api.Services.Foundations.Users;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StorageBroker>();
builder.Services.AddTransient<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IRentService, RentService>();
builder.Services.AddTransient<IBasketService, BasketService>();

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
