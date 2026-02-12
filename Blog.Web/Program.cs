using Blog.Data.EFCore;
using Blog.Data.EFCore.Repositories;
using Blog.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configure EF Core DbContext and repositories for the blog data layer.
var connectionString = builder.Configuration.GetConnectionString("BlogDatabase");
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IBlogEntryRepository, BlogEntryRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

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

app.Run();
