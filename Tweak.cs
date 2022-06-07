using System;

public enum TweakType
{
    FLOAT,
    TOGGLE
}

public abstract class Tweak
{
    public bool Active { get; set; }
    public bool Selected { get; set; }
    public string Label { get; }
    public TweakType Type { get; }
    public Tweak(TweakType type, string label, bool selected = false)
    {
        Type = type;
        Active = false;
        Label = label;
        Selected = selected;
    }

    public bool Activate()
    {
        Active = true;
        return Active;
    }

    public bool Deactivate()
    {
        Active = false;
        return Active;
    }

    public void Render()
    {
        switch (Type)
        {
            case TweakType.TOGGLE:
                GUILayout.Toggle(Active, Label);
                break;
        }
    }
}