using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace IdentityProvider.Logging.Filters;

public class TrackPerformanceFilter : IActionFilter
{
    private PerfTracker _tracker;
    private readonly string _product;
    private readonly string _layer;

    public TrackPerformanceFilter(string product, string layer)
    {
        _product = product;
        _layer = layer;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;
        var activity = $"{request.Path}-{request.Method}";

        var dict = new Dictionary<string, object>();
        foreach (var key in context.RouteData.Values.Keys)
            dict.Add($"RouteData-{key}", (string)context.RouteData.Values[key]);

        var details = WebHelper.GetWebLogDetail(_product, _layer, activity,
            context.HttpContext, dict);

        _tracker = new PerfTracker(details);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _tracker?.Stop();
    }
}

public class TrackActionPerformanceFilter : IActionFilter
{
    private Stopwatch _timer;
    private readonly ILogger<TrackActionPerformanceFilter> _logger;
    private readonly IScopeInformation _scopeInfo;
    private IDisposable _userScope;
    private IDisposable _hostScope;

    public TrackActionPerformanceFilter(
        ILogger<TrackActionPerformanceFilter> logger,
        IScopeInformation scopeInfo)
    {
        _logger = logger;
        _scopeInfo = scopeInfo;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _timer = new Stopwatch();

        var userDict = new Dictionary<string, string>
        {
            { "UserId", context.HttpContext.User.Claims.FirstOrDefault(a => a.Type == "sub")?.Value },
            { "OAuth2 Scopes", string.Join(",",
                context.HttpContext.User.Claims.Where(c => c.Type == "scope").Select(c => c.Value)) }
        };
        _userScope = _logger.BeginScope(userDict);
        _hostScope = _logger.BeginScope(_scopeInfo.HostScopeInfo);

        _timer.Start();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _timer.Stop();
        if (context.Exception == null)
        {
            //_logger.LogRoutePerformance(context.HttpContext.Request.Path,
            //    context.HttpContext.Request.Method,
            //    _timer.ElapsedMilliseconds);
        }
        _userScope?.Dispose();
        _hostScope?.Dispose();
    }
}