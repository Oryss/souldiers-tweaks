namespace SouldiersTweaks
{
    public abstract class Tweak
    {
        public string Label { get; }
        public bool Activated { get; set; }
        public string PlayerPrefKey { get; }
        public Tweak(string label)
        {
            Label = label;
            PlayerPrefKey = GetType().Name;
            Activated = false;
        }

        public abstract void Render();
        public abstract void Save();
        public abstract void Load();
        public abstract void Reset();
    }
}
   