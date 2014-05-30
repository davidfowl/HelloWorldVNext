using Microsoft.AspNet.Builder;

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