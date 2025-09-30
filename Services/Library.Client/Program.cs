using Library.Client.Managers.Books;
using Library.Client.Managers.Library;
using Library.Client.Managers.Members;
using Library.Client.Repositories.Book;
using Library.Client.Repositories.Books;
using Library.Client.Repositories.Library;
using Library.Client.Repositories.Member;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookManager, BookManager>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberManager, MemberManager>();
builder.Services.AddScoped<ILibraryManager, LibraryManager>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
