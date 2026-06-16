namespace Core;

public class PathSettings
{
    public int Id { get; set; }
    public string PathFilename { get; set; } = string.Empty;
    public bool PathThereAndBack { get; set; } = true;
    public bool PathReduceSteps { get; set; }
    public List<string> SideActivityRequirements = [];
}