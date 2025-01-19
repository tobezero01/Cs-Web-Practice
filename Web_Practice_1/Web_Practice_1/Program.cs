var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run(async (HttpContext context) =>
//{
//	string path = context.Request.Path;
//	string method = context.Request.Method;

//	context.Response.Headers["Content-type"] = "text/html";
//	await context.Response.WriteAsync($"<p>{path}</p>");
//	await context.Response.WriteAsync($"<p>{method}</p>");
//});

// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
	await context.Response.WriteAsync("Hello");
	await next(context);
});

// middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
	await context.Response.WriteAsync("Hello");
	await next(context);
});
// middleware 3
app.Run(async (HttpContext context) =>
{
	await context.Response.WriteAsync(" Hello Again");
});

app.Run();