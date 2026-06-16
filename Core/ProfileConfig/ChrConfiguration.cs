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
    
    [JsonConverter(typeof(IntOrIntArrayDictionaryConverter))]
    public Dictionary<string, int[]> IntVariables { get; } = [];

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