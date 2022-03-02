namespace NexTech.Karagumruk.PerformanceAnalyzer.App.Models;

public class Test
{
    public string? Id { get; set; }
    public string Name { get; set; }
    public string Result { get; set; }
    public string Comment { get; set; }
    
    public ICollection<PlayerTest> PlayerTests { get; set; }
}