using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDExample.Filters.ResultFilter
{
	public class TokenResultFilter : IResultFilter
	{
		public void OnResultExecuted(ResultExecutedContext context)
		{
			throw new NotImplementedException();
		}

		public void OnResultExecuting(ResultExecutingContext context)
		{
			context.HttpContext.Response.Cookies.Append("Auth-Key", "A100");
		}
	}
}