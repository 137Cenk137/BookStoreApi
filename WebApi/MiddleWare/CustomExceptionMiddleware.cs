namespace WebApi.MiddleWare;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionMiddleware(RequestDelegate next)
    {
        _next = next;   
    }
    public async Task Invoke(HttpContext context) 
    {
        string message = "[Request] HTTP " + context.Request.Method.ToString() + "-" + context.Request.Path.ToString();
    }
}
{
public static  class CustomExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseCustomExceptionMiddlewareExtension(this IApplicationBuilder builder){
        return builder.UseMiddleware<CustomExceptionMiddleware>();
    }
}