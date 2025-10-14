using FluentValidation;
using Hotel.ATR.Web.Second.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddViewLocalization();

builder.Services.AddScoped<IValidator<ContactForm>, ContactFormValidation>();

//получили строку подключения к БД
string conn = builder.Configuration.GetConnectionString("DefaultConnection");

//решили зависимость 
builder.Services.AddDbContext<AppIdentityDbContext>(options => 
options.UseSqlServer(conn));

//настройка Identity
builder.Services
    .AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var supportedCulture = new[] { "en-US", "kk-KZ", "ru-RU" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("kk-KZ")
    .AddSupportedCultures(supportedCulture)
    .AddSupportedUICultures(supportedCulture);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
