using System.Text;

namespace creatingMiddlewares.Middlewares
{
    /*
     * Eğer HttpRequest Metodu Post ise ve JSON değeri içeriyorsa bu değeri analiz için ayır:
     */
    public class JSONBodyMiddleware
    {
        private readonly RequestDelegate _next;

        public JSONBodyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            if (httpContext.Request.Method == "POST" && httpContext.Request.ContentType.StartsWith("application/json"))
            {
                using var reader = new StreamReader(httpContext.Request.Body);
                var json = await reader.ReadToEndAsync();

                var stream = new MemoryStream();
                var content = Encoding.UTF8.GetBytes(json);
                stream.Write(content, 0, content.Length);
                httpContext.Request.Body = stream;
                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);

                httpContext.Items["jsonBody"] = json;

            }
            await _next(httpContext);
        }
    }
}
