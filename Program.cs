using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pustan_Radu_Lab2_bun.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Pustan_Radu_Lab2_bunContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pustan_Radu_Lab2_bunContext") ?? throw new InvalidOperationException("Connection string 'Pustan_Radu_Lab2_bunContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
