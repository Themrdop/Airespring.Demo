using Airespring.Demo.DataAccess;
using Airespring.Demo.DataAccess.Interfaces;
using Airespring.Demo.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IEmployeeProvider, EmployeeProvider>();
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration["DatabaseName"] });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

builder.Services.BuildServiceProvider().GetService<IDatabaseBootstrap>().Setup();

app.Run();
