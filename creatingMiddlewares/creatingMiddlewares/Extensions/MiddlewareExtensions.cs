using creatingMiddlewares.Middlewares;

namespace creatingMiddlewares.Extensions
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Gelen request metodu post ise ve istenmeyen kelimeler varsa BadRequest döndüren middleware
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseBadwordsHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<JSONBodyMiddleware>();
            app.UseMiddleware<BadwordsHandlerMiddleware>();
            return app;
        }
    }
}
