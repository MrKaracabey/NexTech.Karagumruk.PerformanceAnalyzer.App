namespace NexTech.Karagumruk.PerformanceAnalyzer.App.Models;

public class Player
{
    public string? Id { get; set; }
    public string IdentityNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Position { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public DateTime BirthDay { get; set; }
    
    public ICollection<PlayerTest> PlayerTests { get; set; }
}