using Hardware;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace Core;

public class KeyAction
{
    [JsonIgnore]
    public BitVector32 features = new(ActionMask.Log | ActionMask.BeforeCastDismount);

    public string Name { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;

    public ModifierKey Modifier { get; set; } = ModifierKey.None; 
    public bool HasModifier => Modifier != ModifierKey.None;

    public float Cost { get; set; } = 18;

    /// <summary>
    /// NPC Goal 专用
    /// </summary>
    public string PathFilename { get; set; } = string.Empty;

    public int PressDuration { get; set; } = InputDuration.DefaultPress;

    public string InCombat { get; set; } = "false";

    public Form Form { get; init; }

    public int Cooldown { get; set; } = TimeConstants.SPELL_QUEUE;
    public int Charge { get; set; } = 1;

    public SchoolMask School { get; set; }

    public string MacroText { get; set; } = string.Empty;

    public bool Item
    {
        get => features[ActionMask.Item];
        set => features[ActionMask.Item] = value;
    }

        public bool HasCastBar 
    {
        get => features[ActionMask.HasCastBar];
        set => features[ActionMask.HasCastBar] = value;
    }

}