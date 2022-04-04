using SiteHandlingSigterm;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHostedService<ApplicationLifetimeService>();
builder.Services.Configure<LifetimeOptions>(
    builder.Configuration.GetSection(LifetimeOptions.SectionName));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
