using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.DataAccess.Context;
using OnlineEducation.Entity.Entities;
using OnlineEducation.UI.Services.RoleServices;
using OnlineEducation.UI.Services.UserServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.LoginPath = "/Login/SignIn";
            options.LogoutPath = "/Login/Logout";
            options.AccessDeniedPath = "/ErrorPage/AccessDenied";
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            options.Cookie.Name = "RensEducationJWT";
        });



builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseStatusCodePagesWithReExecute("/ErrorPage/NotFound404/");
app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
