using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Leavemanagement.Models;

namespace Leavemanagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        var exceptionHandlerPathfeature =  HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathfeature) != null)
        {
            Exception exception = exceptionHandlerPathfeature.Error;
            _logger.LogEror(exceptio, $"Error Encounter by User: {this.user?.Identity?.Name} | Request Id: {requestId}")
        };
        return View(new ErrorViewModel {  RequestId  =RequestId });
    }
}
