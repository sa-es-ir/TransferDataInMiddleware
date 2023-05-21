namespace MiddlewareTransferData.Middlewares;

public class MiddlewareB
{

    private readonly RequestDelegate _next;

    public MiddlewareB(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, TransferDataService transferService)
    {
        // Approach 1: using request headers
        var aData1 = context.Request.Headers["A-Data"];

        // Approach 2: using HttpContext Items
        var aData2 = context.Items["A-Data"];

        // Aproach 3: using HttpContext features
        var aData3 = context.Features.Get<TransferDataFeature>();

        // Aproach 4: using Scoped services
        var aData4 = transferService.AData;

        await _next(context);
    }
}
