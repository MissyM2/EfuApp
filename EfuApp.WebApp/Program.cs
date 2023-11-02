using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using EfuApp.WebApp.Data;
using EfuApp.Plugins.InMemory;
using EfuApp.UseCases.Courses;
using EfuApp.UseCases.PluginInterfaces;
using EfuApp.UseCases;
using EfuApp.UseCases.Deliverables;
using EfuApp.UseCases.Suggestions;
using EfuApp.UseCases.Terms;
using EfuApp.UseCases.Weeks;
////using EfuApp.Plugins.Sqlite;
using EfuApp.Plugins.EfCoreSqlServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//var constr = builder.Configuration.GetConnectionString("EfuApp");

builder.Services.AddDbContext<EfuAppContext>(options =>
{
    // the UseSqlServer method is accessing the connection string from builder.Configuration
    //options.UseSqlServer(constr);
    options.UseSqlServer(builder.Configuration.GetConnectionString("EfuApp"));
});

// builder.Services.AddDbContextFactory<EfuAppContext>(options =>
// {
//     // the UseSqlServer method is accessing the connection string from builder.Configuration
//     options.UseSqlServer(constr);
// });

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// builder.Services.AddSingleton<ICourseRepository, CourseInMemoryRepository>();
// builder.Services.AddSingleton<IDeliverableRepository, DeliverableInMemoryRepository>();
// builder.Services.AddSingleton<ISuggestionRepository, SuggestionInMemoryRepository>();
// builder.Services.AddSingleton<ITermRepository, TermInMemoryRepository>();
// builder.Services.AddSingleton<IWeekRepository, WeekInMemoryRepository>();

// builder.Services.AddSingleton<ICourseRepository, CourseSqliteRepository>();
// builder.Services.AddSingleton<IDeliverableRepository, DeliverableSqliteRepository>();
// builder.Services.AddSingleton<ISuggestionRepository, SuggestionSqliteRepository>();
// builder.Services.AddSingleton<ITermRepository, TermSqliteRepository>();
// builder.Services.AddSingleton<IWeekRepository, WeekSqliteRepository>();

builder.Services.AddTransient<ICourseRepository, CourseEFCoreRepository>();
builder.Services.AddTransient<IDeliverableRepository, DeliverableEfCoreRepository>();
builder.Services.AddTransient<ISuggestionRepository, SuggestionEfCoreRepository>();
builder.Services.AddTransient<ITermRepository, TermEfCoreRepository>();
builder.Services.AddTransient<IWeekRepository, WeekEfCoreRepository>();


builder.Services.AddTransient<IViewCoursesByNameUseCase, ViewCoursesByNameUseCase>();
builder.Services.AddTransient<IAddCourseUseCase, AddCourseUseCase>();
builder.Services.AddTransient<IEditCourseUseCase, EditCourseUseCase>();
builder.Services.AddTransient<IViewCourseByIdUseCase, ViewCourseByIdUseCase>();

builder.Services.AddTransient<IViewDeliverablesByNameUseCase, ViewDeliverablesByNameUseCase>();
builder.Services.AddTransient<IAddDeliverableUseCase, AddDeliverableUseCase>();
builder.Services.AddTransient<IEditDeliverableUseCase, EditDeliverableUseCase>();
builder.Services.AddTransient<IViewDeliverableByIdUseCase, ViewDeliverableByIdUseCase>();
builder.Services.AddTransient<IViewDeliverablesByDateUseCase, ViewDeliverablesByDateUseCase>();

builder.Services.AddTransient<IViewSuggestionsByNameUseCase, ViewSuggestionsByNameUseCase>();
builder.Services.AddTransient<IAddSuggestionUseCase, AddSuggestionUseCase>();
builder.Services.AddTransient<IEditSuggestionUseCase, EditSuggestionUseCase>();
builder.Services.AddTransient<IViewSuggestionByIdUseCase, ViewSuggestionByIdUseCase>();

builder.Services.AddTransient<IViewTermsByNameUseCase, ViewTermsByNameUseCase>();
builder.Services.AddTransient<IAddTermUseCase, AddTermUseCase>();
builder.Services.AddTransient<IEditTermUseCase, EditTermUseCase>();
builder.Services.AddTransient<IViewTermByIdUseCase, ViewTermByIdUseCase>();

builder.Services.AddTransient<IViewWeeksByNameUseCase, ViewWeeksByNameUseCase>();
builder.Services.AddTransient<IAddWeekUseCase, AddWeekUseCase>();
builder.Services.AddTransient<IEditWeekUseCase, EditWeekUseCase>();
builder.Services.AddTransient<IViewWeekByIdUseCase, ViewWeekByIdUseCase>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
