using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core;

public partial class ChrConfiguration
{
    public bool Log { get; set; } = true;
    public bool LogBagChanges { get; set; } = true;
    public bool Loot { get; set; } = true;
    public bool Skin { get; set; }
    public bool Herb { get; set; }
    public bool Mine { get; set; }
    public bool Salvage { get; set; }
    public bool UseMount { get; set; } = true;
    public bool AllowPvP { get; set; }
    public bool TargetNeutral { get; set; }
    public bool AutoPetAttack { get; set; } = true;
    public bool CrossZoneSearch { get; set; }
    public bool KeyboardOnly { get; set; }

    public string PathFilename { get; set; } = string.Empty;
    public bool PathThereAndBack { get; set; } = true;
    public bool PathReduceSteps { get; set; }
    public List<string> SideActivityRequirements = [];

    public PathSettings[] Paths { get; set; } = [];

    public int NPCMaxLevels_Above { get; set; } = 1;
    public int NPCMaxLevels_Below { get; set; } = 7;

    public bool CheckTargetGivesExp { get; set; }

    public string[] Blacklist { get; init; } = [];

    public UnitClassification TargetMask { get; set; } =
        UnitClassification.Normal |
        UnitClassification.Trivial |
        UnitClassification.Rare;

    public Dictionary<int, SchoolMask> NpcSchoolImmunity { get; } = [];

    [JsonConverter(typeof(IntOrIntArrayDictionaryConverter))]
    public Dictionary<string, int[]> IntVariables { get; } = [];

    public Dictionary<string, string> StringVariables { get; } = [];

    public KeyActions Pull { get; } = new();
    public KeyActions Flee { get; } = new();
    public KeyActions Combat { get; } = new();
    public KeyActions Adhoc { get; } = new();
    public KeyActions Parallel { get; } = new();
    public KeyActions NPC { get; } = new();
    public KeyActions AssistFocus { get; } = new();
    public WaitKeyActions Wait { get; } = new();

    public bool Mail { get; set; }
    public string MailFilename { get; set; } = string.Empty;
    public MailConfiguration MailConfig { get; set; } = new();

    public ConsoleKey ForwardKey { get; init; } = ConsoleKey.UpArrow;
    public ConsoleKey BackwardKey { get; init; } = ConsoleKey.DownArrow;
    public ConsoleKey TurnLeftKey { get; init; } = ConsoleKey.LeftArrow;
    public ConsoleKey TurnRightKey { get; init; } = ConsoleKey.RightArrow;
}

public class IntOrIntArrayDictionaryConverter : JsonConverter<Dictionary<string, int[]>>
{
    public override Dictionary<string, int[]>? ReadJson(
        JsonReader reader,
        Type objectType,
        Dictionary<string, int[]>? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        var result = new Dictionary<string, int[]>();

        var obj = JObject.Load(reader);

        foreach (var property in obj.Properties())
        {
            if (property.Value.Type == JTokenType.Array)
            {
                result[property.Name] = property.Value
                    .Select(t => (int)t!)
                    .ToArray();
            }
            else if (property.Value.Type == JTokenType.Integer)
            {
                result[property.Name] = [(int)property.Value!];
            }
        }

        return result;
    }

    public override void WriteJson(
        JsonWriter writer,
        Dictionary<string, int[]>? value,
        JsonSerializer serializer)
    {
        var obj = new JObject();

        if (value is not null)
        {
            foreach (var kvp in value)
            {
                if (kvp.Value.Length == 1)
                {
                    obj[kvp.Key] = kvp.Value[0];
                }
                else
                {
                    obj[kvp.Key] = new JArray(kvp.Value);
                }
            }
        }

        obj.WriteTo(writer);
    }
}