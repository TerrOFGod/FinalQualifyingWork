namespace TextGenerator.Core.Models.Actors;

public class WorldContext
{
    public string LocationDescription { get; set; }
    public List<string> RecentEvents { get; set; }
    public Dictionary<string, string> EntityStates { get; set; }
    public float TimeOfDay { get; set; }
}