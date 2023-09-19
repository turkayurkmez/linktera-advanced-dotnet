namespace creatingMiddlewares.Middlewares
{
    public class BadwordsHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public BadwordsHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Items.TryGetValue("jsonBody", out object? json))
            {
                var badWords = new List<string> { "pis", "kaka", "kötü" };
                var jsonContent = (string?)json;
                if (badWords.Any(jsonContent.Contains))
                {
                    httpContext.Response.StatusCode = 400;
                    httpContext.Response.ContentType = "application/json";
                    httpContext.Response.WriteAsJsonAsync(new { message = "Olmaz böyle terbiyesiz yorum" });
                    return;
                }
            }

            await _next(httpContext);
        }
    }
}
