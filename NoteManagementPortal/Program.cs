using NoteManagementPortal.Service;
using NoteManagementPortal.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<APIService>(

    client =>
    {
        client.BaseAddress = new Uri("https://localhost:44373");
        // Add other client configurations if needed
    }
    );
builder.Services.AddScoped<IAPIService, APIService>();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MySessionCookie"; // Set a custom cookie name
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.IsEssential = true; // Make the cookie essential for GDPR compliance
});

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


app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.Run();
