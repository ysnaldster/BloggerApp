namespace BlogApplication.Api.Middlewares;

//Middleware para saber la hora actual del servidor
public class TimeMiddleware
{
    //Nos indica que vamos a utilizar el middleware que viene de acuerdo al orden que existe.
    private readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context) //HttpContext representa toda la información del request
    {
        //Esto invoca al ultimo middleware que se ejecuto 
        await next(context);
        
        if(context.Request.Query.Any(p => p.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
        }
    }
    
}

public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}