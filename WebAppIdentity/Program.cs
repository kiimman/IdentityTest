using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppIdentity.Contexts;
using WebAppIdentity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabase")));
builder.Services.AddScoped<AuthService>();
builder.Services.AddDefaultIdentity<IdentityUser>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = false;
}).AddEntityFrameworkStores<IdentityContext>();



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
