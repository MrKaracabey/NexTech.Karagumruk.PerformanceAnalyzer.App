using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexTech.Karagumruk.PerformanceAnalyzer.App.Data;
using NexTech.Karagumruk.PerformanceAnalyzer.App.Models;

namespace NexTech.Karagumruk.PerformanceAnalyzer.App.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
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

        var deepSquadTest = new Test()
        {
            Id = Convert.ToString(Guid.NewGuid()),
            Name = "DeepSquad",
            Result = resultTextArea1,
            Comment = commentTextArea1

        };

        var horizontalJumoTest  = new Test()
        {
            Id = Convert.ToString(Guid.NewGuid()),
            Name = "HorizontalJump",
            Result = resultTextArea2,
            Comment = commentTextArea2

        };

        var sprintTest  = new Test()
        {
            Id = Convert.ToString(Guid.NewGuid()),
            Name = "Sprint",
            Result = resultTextArea3,
            Comment = commentTextArea3
        };

        var flamingoDengeTest  = new Test()
        {
            Id = Convert.ToString(Guid.NewGuid()),
            Name = "FlamingoDenge",
            Result = resultTextArea4,
            Comment = commentTextArea4
        };

        var proAglitiyTest  = new Test()
        {
            Id = Convert.ToString(Guid.NewGuid()),
            Name = "ProAgility",
            Result = resultTextArea5,
            Comment = commentTextArea5
        };

        var futbolKordinasyonTest  = new Test()
        {
            Id = Convert.ToString(Guid.NewGuid()),
            Name = "FutbolKordinasyon",
            Result = resultTextArea6,
            Comment = commentTextArea6
        };

        _context.Players.Add(player);
        
        _context.Tests.Add(deepSquadTest);
        _context.Tests.Add(horizontalJumoTest);
        _context.Tests.Add(sprintTest);
        _context.Tests.Add(flamingoDengeTest);
        _context.Tests.Add(proAglitiyTest);
        _context.Tests.Add(futbolKordinasyonTest);

        var PlayerdeepSquadTest = new PlayerTest()
        {
            PlayerId = player.Id,
            TestId = deepSquadTest.Id
        };

        var PlayerhorizontalJumoTest = new PlayerTest()
        {
            PlayerId = player.Id,
            TestId = horizontalJumoTest.Id
        };
        
        var PlayersprintTest = new PlayerTest()
        {
            PlayerId = player.Id,
            TestId = sprintTest.Id
        };
        
        var PlayeflamingoDengeTest = new PlayerTest()
        {
            PlayerId = player.Id,
            TestId = flamingoDengeTest.Id
        };
        
        var PlayeproAglitiyTest = new PlayerTest()
        {
            PlayerId = player.Id,
            TestId = proAglitiyTest.Id
        };

        
        var playerfutbolKordinasyonTest = new PlayerTest()
        {
            PlayerId = player.Id,
            TestId = futbolKordinasyonTest.Id
        };



        _context.PlayerTest.Add(PlayerdeepSquadTest);
        _context.PlayerTest.Add(PlayerhorizontalJumoTest);
        _context.PlayerTest.Add(PlayersprintTest);
        _context.PlayerTest.Add(PlayeflamingoDengeTest);
        _context.PlayerTest.Add(PlayeproAglitiyTest);
        _context.PlayerTest.Add(playerfutbolKordinasyonTest);

        _context.SaveChanges();
        
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