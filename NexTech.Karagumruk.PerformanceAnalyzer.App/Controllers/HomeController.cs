using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexTech.Karagumruk.PerformanceAnalyzer.App.Models;

namespace NexTech.Karagumruk.PerformanceAnalyzer.App.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string firstName, string lastName)
    {
        ViewBag.Name = string.Format("Name: {0} {1}", firstName, lastName);
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(
        string tc, string name, string surname, string position,
        string height, string weight, string birthdate,
        string resultTextArea1, string  commentTextArea1,
        string resultTextArea2, string  commentTextArea2,
        string resultTextArea3, string  commentTextArea3,
        string resultTextArea4, string  commentTextArea4,
        string resultTextArea5, string  commentTextArea5,
        string resultTextArea6, string  commentTextArea6
    )
    {
        var player = new Player
        {
            Id = Convert.ToString(Guid.NewGuid()),
            IdentityNumber = tc,
            Name = name,
            Surname =surname,
            Position = position,
            Height = Convert.ToInt32(height),
            Weight =Convert.ToInt32(weight),
            BirthDay = Convert.ToDateTime(birthdate)
        };

        var deepSquad = new Test()
        {
            Id = "1",
            Name = "DeepSquad",
            Result = resultTextArea1,
            Comment = commentTextArea1

        };

        var horizontalJumo = new Test()
        {
            Id = "2",
            Name = "HorizontalJump",
            Result = resultTextArea2,
            Comment = commentTextArea2

        };

        var sprint = new Test()
        {
            Id = "3",
            Name = "Sprint",
            Result = resultTextArea3,
            Comment = commentTextArea3
        };

        var flamingoDenge = new Test()
        {
            Id = "4",
            Name = "FlamingoDenge",
            Result = resultTextArea4,
            Comment = commentTextArea4
        };

        var proAglitiy = new Test()
        {
            Id = "5",
            Name = "ProAgility",
            Result = resultTextArea5,
            Comment = commentTextArea5
        };

        var futbolKordinasyon = new Test()
        {
            Id = "6",
            Name = "FutbolKordinasyon",
            Result = resultTextArea6,
            Comment = commentTextArea6
        };



        Console.WriteLine(player);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}