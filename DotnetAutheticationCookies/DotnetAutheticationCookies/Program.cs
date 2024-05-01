using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews ();

builder.Services.AddAuthentication (
    CookieAuthenticationDefaults.AuthenticationScheme )
    .AddCookie ( option => {
        option.LoginPath = "/Authentication/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes ( 20 );

    } );

var app = builder.Build();

if ( !app.Environment.IsDevelopment () ) {
    app.UseExceptionHandler ( "/Home/Error" );
}

app.UseStaticFiles ();

app.UseRouting ();

app.UseAuthorization ();

app.MapControllerRoute (
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}" );

app.Run ();
