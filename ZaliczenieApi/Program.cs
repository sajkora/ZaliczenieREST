using Microsoft.EntityFrameworkCore;
using ZaliczenieApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders(); // Usuniêcie domyœlnych dostawców logowania
    logging.AddConsole(); // Dodanie dostawcy logowania konsoli
    logging.AddDebug(); // Dodanie dostawcy logowania debugowania
    logging.AddEventLog(); // Dodanie dostawcy logowania zdarzeñ systemowych
    logging.AddEventSourceLogger(); // Dodanie dostawcy logowania Ÿród³a zdarzeñ
});
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PictureContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PictureContext")));

// Add support for multipart/form-data

builder.Services.AddRazorPages();
builder.Services.AddAntiforgery();
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true; // Required for synchronous I/O operations in controllers
});

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

// Add support for multipart/form-data
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.Run();