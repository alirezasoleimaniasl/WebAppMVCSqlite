using LineList.Data;
using Microsoft.EntityFrameworkCore;
using WebAppMVCSqlite.Areas.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddMvc(x => x.EnableEndpointRouting = false);

builder.Services.AddDbContext<LineListContext>
    (options => options.UseSqlite(String.Format("Filename={0}/data.sqlite", AppDomain.CurrentDomain.BaseDirectory)));

builder.Services.AddTransient<ConvertDate>();
builder.Services.AddTransient<IConvertDate,ConvertDate>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
//app.UseMvc();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
