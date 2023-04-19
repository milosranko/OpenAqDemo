using OpenAq.Test.Abstractions.Interfaces;
using OpenAq.Test.Integrations.Services.OpenAq;
using OpenAq.Test.Web.Filters;
using OpenAq.Test.Web.Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAirQualityService, OpenAqService>();
builder.Services.AddTransient<IAqModelBuilderService, AqModelBuilderService>();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

//HTTP 404 handler
app.Use(async (context, next) =>
{
	await next();
	if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)

	{
		context.Request.Path = "/Home/NotFound";
		await next();
	}
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseMiddleware<ExceptionFilter>();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
