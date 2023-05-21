namespace MiddlewareTransferData.Middlewares;

public class MiddlewareA
{
    private readonly RequestDelegate _next;

    public MiddlewareA(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, TransferDataService transferService)
    {
        var aData = "I'm from MiddlewareA";

        // Approach 1: using request headers
        context.Request.Headers.TryAdd("A-Data", aData);

        // Approach 2: using HttpContext Items
        context.Items.Add("A-Data", aData);

        // Approach 3: using HttpContext Features
        context.Features.Set(new TransferDataFeature { AData = aData });

        // Aproach 4: using Scoped services
        transferService.AData = aData;

        await _next(context);
    }
}

public class TransferDataFeature
{
    public string AData { get; set; }
}
