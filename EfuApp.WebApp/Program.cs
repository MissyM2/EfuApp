using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using EfuApp.WebApp.Data;
using EfuApp.Plugins.InMemory;
using EfuApp.UseCases.Courses;
using EfuApp.UseCases.PluginInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<ICourseRepository, CourseRepository>();

builder.Services.AddTransient<IViewCoursesByNameUseCase, ViewCoursesByNameUseCase>();
builder.Services.AddTransient<IAddCourseUseCase, AddCourseUseCase>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
