namespace Web_Practice_1.CustomMiddleware
{
	public class MyCustomMiddleWare : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			await context.Response.WriteAsync("My Custom - Starts");
			await next(context);
			await context.Response.WriteAsync("My Custom - Ends");
		}
	}

	public static class CustomMiddlewareExtension
	{
		public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
		{
			return app.UseMiddleware<MyCustomMiddleWare>();
		}
	}
}