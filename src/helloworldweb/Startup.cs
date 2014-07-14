using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

public class Startup
{
    public void Configure(IBuilder app)
    {
        app.Run(async context =>
        {
            var payload = "Hello World";
            context.Response.ContentLength = payload.Length;
            await context.Response.WriteAsync(payload);
        });
    }
}