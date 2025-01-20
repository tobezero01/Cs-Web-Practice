using Web_Practice_1.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleWare>();
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
	await context.Response.WriteAsync(" middleware 1 ");
	await next(context);
});

// middleware 2
//app.UseMiddleware();
app.UseHelloMiddleware();
// middleware 3
app.Run(async (HttpContext context) =>
{
	await context.Response.WriteAsync(" middleware 3 ");
});

app.Run();