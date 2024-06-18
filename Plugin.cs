using BepInEx;
using BepInEx.Configuration;

namespace NoWetAsh;

[BepInPlugin(ModGUID, ModName, ModVersion)]
internal class Plugin : BaseUnityPlugin
{
    internal const string ModName = "Frogger.NoWetAsh",
        ModAuthor = "Frogger",
        ModVersion = "0.1.0",
        ModGUID = $"com.{ModAuthor}.{ModName}";
    
    public static ConfigEntry<bool> removeWet;
    public static ConfigEntry<float> maxTtl;

    private void Awake()
    {
        CreateMod(this, ModName, ModAuthor, ModVersion, ModGUID);
        removeWet = config("General", "Remove wet effect in Ashlands", false, "");
        maxTtl = config("General", "Maximum time to wet effect", 3f, "");
    }
}