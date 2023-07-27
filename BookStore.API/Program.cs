using BookStore.Application.Mappings;
using BookStore.Application.Services.Books;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Repositories;
using MongoDB.Driver;
using NotesApp.Infrastructure.MongoData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Mongo Db config
var mongoDbSettingsSection = builder.Configuration.GetSection("MongoDbSettings");
builder.Services.Configure<MongoDbSettings>(mongoDbSettingsSection);

var mongoDbSettings = mongoDbSettingsSection.Get<MongoDbSettings>();
builder.Services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(mongoDbSettings?.ConnectionString));

builder.Services.AddSingleton<IMongoDatabase>(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(mongoDbSettings.DatabaseName));

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddAutoMapper(typeof(BookAutoMapper));

builder.Services.AddControllers();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }
