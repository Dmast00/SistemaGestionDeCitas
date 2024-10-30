using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaGestionDeCitas.Identity;
using SistemaGestionDeCitas.Identity.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(x => 
        x.UseSqlServer(builder.Configuration.GetConnectionString("default"))
    );
builder.Services.AddIdentity<User, IdentityRole>(x =>
{
    //Password
    x.Password.RequiredLength = 8;
    x.Password.RequireNonAlphanumeric = false;
    

    //Email
    x.SignIn.RequireConfirmedEmail = false;
    


    //Lockout
    x.Lockout.MaxFailedAccessAttempts = 4;
})
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<AppDbContext>();

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

app.MapRazorPages().RequireAuthorization();

app.Run();
