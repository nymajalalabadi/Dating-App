using Data.Context;
using DatingApp.Api.Extensions;
using DatingApp.Api.Services.Implementation;
using DatingApp.Api.Services.Interface;
using IOC.Dependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region add services

builder.Services.RegisterServices();

builder.Services.AddApplicationService(builder.Configuration);

#endregion

#region Add cors

builder.Services.AddCors();

#endregion

#region Add identity

builder.Services.AddIdentityService(builder.Configuration);

#endregion


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

#region Use cors

app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

#endregion

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
