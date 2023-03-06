using Microsoft.EntityFrameworkCore;
using ShopWebApplication.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add session service
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddDbContext<PizzaStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaDb2")));

// Add filter
builder.Services.AddMvc();

builder.Services.AddTransient(typeof(PizzaStoreContext), typeof(PizzaStoreContext));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}"
);

app.UseSession();

//app.UseAuthentication();

app.MapRazorPages();

app.Run();
