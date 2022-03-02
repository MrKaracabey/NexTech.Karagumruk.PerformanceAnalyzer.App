using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NexTech.Karagumruk.PerformanceAnalyzer.App.Models;

namespace NexTech.Karagumruk.PerformanceAnalyzer.App.Controllers;

public class ResultController : Controller
{
    private readonly ILogger<ResultController> _logger;

    public ResultController(ILogger<ResultController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string firstName, string lastName)
    {
        ViewBag.Name = string.Format("Name: {0} {1}", firstName, lastName);
        return View();
    }
    
  

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}