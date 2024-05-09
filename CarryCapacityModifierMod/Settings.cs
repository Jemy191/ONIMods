using Newtonsoft.Json;
using PeterHan.PLib.Options;

namespace CarryCapacityModifierMod
{
    [JsonObject(MemberSerialization.OptIn)]
    [ModInfo("https://github.com/Jemy191/ONIMods")]
    public class Settings
    {
        [Option("Carry capacity modifier", "Add a modifier to duplicants' carry capacity.")]
        [Limit(-1000, 1000)]
        [JsonProperty]
        public float CarryModifier { get; set; }

        [Option("Modifier is multiplicative additive", "If True the modifier is Carry capacity + X% if False the modifier is Carry capacity + X where X is the Carry capacity modifier.")]
        [JsonProperty]
        public bool IsMultiplier { get; set; }

        public Settings()
        {
            CarryModifier = 100;
            IsMultiplier = true;
        }
    }
}