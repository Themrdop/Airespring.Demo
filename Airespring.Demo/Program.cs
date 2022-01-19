using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Configuration.AddJsonFile("appsettings.json", false, true);

builder.Services.AddSingleton<IEmployeeProvider, EmployeeProvider>();
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration["DatabaseName"] });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

builder.Services.AddOptions();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "AirespringDemo", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airespring demo"));
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseCors(builder => builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin());

app.ConfigureApi();

builder.Services.BuildServiceProvider().GetService<IDatabaseBootstrap>().Setup();

app.Run();
