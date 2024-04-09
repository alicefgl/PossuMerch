using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using PossuMerch.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<dbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PossuMerch")));

builder.Services
    .AddIdentity<Utente, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<dbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
});

// Add external authentication providers
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        IConfigurationSection googleAuthNSection =
            builder.Configuration.GetSection("Authentication:Google");
        options.ClientId = googleAuthNSection["ClientId"];
        options.ClientSecret = googleAuthNSection["ClientSecret"];
    })
    .AddFacebook(options =>
    {
        IConfigurationSection FBAuthNSection =
            builder.Configuration.GetSection("Authentication:FB");
        options.ClientId = FBAuthNSection["ClientId"];
        options.ClientSecret = FBAuthNSection["ClientSecret"];
    })
    .AddMicrosoftAccount(microsoftOptions =>
    {
        microsoftOptions.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"];
        microsoftOptions.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"];
    })
    .AddTwitter(twitterOptions =>
    {
        twitterOptions.ConsumerKey = builder.Configuration["Authentication:Twitter:ConsumerAPIKey"];
        twitterOptions.ConsumerSecret = builder.Configuration["Authentication:Twitter:ConsumerSecret"];
        twitterOptions.RetrieveUserDetails = true;
    });

// This was previously at the first position...
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }

    }
}

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

app.UseAuthentication(); // Use authentication before authorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
