namespace Web_Practice_1.CustomMiddleware
{
	public class HelloCustomMiddleware
	{
		private readonly RequestDelegate _next;

		public HelloCustomMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			if (context.Request.Query.ContainsKey("firstname")
				&& context.Request.Query.ContainsKey("lastname"))
			{
				string fullName = context.Request.Query["firstname"] + " " +
					context.Request.Query["lastname"];
				await context.Response.WriteAsync(fullName);
			}
			await _next(context);
			// after logic
		}
	}

	public static class HelloCustomMiddlewareExtensions
	{
		public static IApplicationBuilder UseHelloMiddleware(this IApplicationBuilder app)
		{
			return app.UseMiddleware<HelloCustomMiddleware>();
		}
	}
}