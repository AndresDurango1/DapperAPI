using Data;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<LibraryDBContext>();
builder.Services.AddTransient<PeopleDBContext>();

builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

builder.Services.AddControllers();

builder.Services.Configure<ConnectionStringsOptions>
    (builder.Configuration.GetSection(ConnectionStringsOptions.Conn));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
