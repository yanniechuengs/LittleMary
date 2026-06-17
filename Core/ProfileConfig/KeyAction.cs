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

    // NPC Goal 专用
    public string PathFilename { get; set; } = string.Empty;

    public int PressDuration { get; set; } = InputDuration.DefaultPress;

    public string InCombat { get; set; } = "false";

    public Form Form { get; init; }

    public int Cooldown { get; set; } = TimeConstants.SPELL_QUEUE;
    public int Charge { get; set; } = 1;

    public SchoolMask School { get; set; }

    public string MacroText { get; set; } = string.Empty;

    public TriState UseWhenTargetIsCasting { get; set; }

    public List<string> Requirements { get; } = [];
    public Requirement[] RequirementsRuntime { get; set; } = [];


    public List<string> Interrupts { get; } = [];
    public Requirement[] InterruptsRuntime { get; set; } = [];

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

    public bool BaseAction
    {
        get => features[ActionMask.BaseAction];
        set => features[ActionMask.BaseAction] = value;
    }

    public bool CancelOnInterrupt
    {
        get => features[ActionMask.CancelOnInterrupt];
        set => features[ActionMask.CancelOnInterrupt] = value;
    }

    public bool ResetOnNewTarget
    {
        get => features[ActionMask.ResetOnNewTarget];
        set => features[ActionMask.ResetOnNewTarget] = value;
    }

    public bool Log
    {
        get => features[ActionMask.Log];
        set => features[ActionMask.Log] = value;
    }

    public bool UseMount
    {
        get => features[ActionMask.UseMount];
        set => features[ActionMask.UseMount] = value;
    }

    public int BeforeCastDelay { get; set; }
    public int BeforeCastMaxDelay { get; set; }

    public bool BeforeCastFaceTarget
    {
        get => features[ActionMask.BeforeCastFaceTarget];
        set => features[ActionMask.BeforeCastFaceTarget] = value;
    }

        public bool BeforeCastStop
    {
        get => features[ActionMask.BeforeCastStop];
        set => features[ActionMask.BeforeCastStop] = value;
    }
    public bool BeforeCastDismount
    {
        get => features[ActionMask.BeforeCastDismount];
        set => features[ActionMask.BeforeCastDismount] = value;
    }

    public int AfterCastDelay { get; set; }
    public int AfterCastMaxDelay { get; set; }
    public int AfterCastStepBack { get; set; }

    public bool AfterCastWaitMeleeRange
    {
        get => features[ActionMask.AfterCastWaitMeleeRange];
        set => features[ActionMask.AfterCastWaitMeleeRange] = value;
    }
    public bool AfterCastWaitBuff
    {
        get => features[ActionMask.AfterCastWaitBuff];
        set => features[ActionMask.AfterCastWaitBuff] = value;
    }
    public bool AfterCastWaitBag
    {
        get => features[ActionMask.AfterCastWaitBag];
        set => features[ActionMask.AfterCastWaitBag] = value;
    }
    public bool AfterCastWaitSwing
    {
        get => features[ActionMask.AfterCastWaitSwing];
        set => features[ActionMask.AfterCastWaitSwing] = value;
    }
    public bool AfterCastWaitCastbar
    {
        get => features[ActionMask.AfterCastWaitCastbar];
        set => features[ActionMask.AfterCastWaitCastbar] = value;
    }
    public bool AfterCastWaitCombat
    {
        get => features[ActionMask.AfterCastWaitCombat];
        set => features[ActionMask.AfterCastWaitCombat] = value;
    }
    public bool AfterCastWaitGCD
    {
        get => features[ActionMask.AfterCastWaitGCD];
        set => features[ActionMask.AfterCastWaitGCD] = value;
    }
    public bool AfterCastAuraExpected
    {
        get => features[ActionMask.AfterCastAuraExpected];
        set => features[ActionMask.AfterCastAuraExpected] = value;
    }

    public void Initialize()
    {
    }
}