var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Use(async (context, next) =>
//{
//	Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
//	if(endpoint != null)
//	{
//		await context.Response.WriteAsync($"Endpoint : {endpoint.DisplayName}");

//	}
//	await next();
//});

app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(static endpoints =>
{
	// add your endpoint
	endpoints.Map("map1", async (context) =>
	{
		await context.Response.WriteAsync("In Map 1");
	});

	endpoints.Map("map2", async (context) =>
	{
		await context.Response.WriteAsync("In Map 2");
	});
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run();