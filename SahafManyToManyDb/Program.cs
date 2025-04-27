using Microsoft.EntityFrameworkCore;
using SahafManyToManyDb.Data;
using SahafManyToManyDb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// dbcontext in dependency injection i�in service olarak eklenmesi
builder.Services.AddDbContext<SahafDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SahafConnection")));

// Identity i�in gerekli olan servislerin eklenmesi
builder.Services.AddDefaultIdentity<Yazar>()
    .AddEntityFrameworkStores<SahafDbContext>();

// yetkisiz bir butona bas�nca default olan Identity/Account/Login sayfas� yerine a�a��daki route a gitmesi i�in;
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// authorize ve authenticate middleware lerinin eklenmesi
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
