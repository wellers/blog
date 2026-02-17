using Blog.Data.EFCore;
using Blog.Data.EFCore.Repositories;
using Blog.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configure EF Core DbContext and repositories for the blog data layer.
builder.Services.AddDbContext<MongoDbContext>();
builder.Services.AddScoped<IBlogEntryRepository, BlogEntryRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

#if DEBUG
// Set-up test data
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<MongoDbContext>();
	await DataGenerator.InitialiseAsync(context);
}
#endif

app.Run();
