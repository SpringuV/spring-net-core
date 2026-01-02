// Program.cs
// Summary: Application entry point - configures DI, session storage, and request pipeline for the sample app.

using HttpContextExcercise;
using HttpContextExcercise.MySession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Register the file-backed session storage engine as a singleton using an injected IHostEnvironment to
// determine the ContentRootPath and create a "SessionStorage" directory inside the app root.
builder.Services.AddSingleton<IMySessionStorageEngine>(services =>
        {
            var path = Path.Combine(services.GetRequiredService<IHostEnvironment>().ContentRootPath, "SessionStorage");
            Directory.CreateDirectory(path);
            return new FileMySessionStorageEngine(path);
        }
    );
// Register the MySessionStorage which manages in-memory sessions and uses the storage engine
builder.Services.AddSingleton<IMySessionStorage, MySessionStorage>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();