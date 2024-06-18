namespace NoWetAsh.Patch;

[HarmonyWrapSafe]
public class RemoveWetInAshlands
{
    [HarmonyPatch(typeof(SEMan), nameof(SEMan.Update))]
    [HarmonyPostfix]
    public static void PatchUpdate(SEMan __instance)
    {
        var wet = __instance.GetStatusEffects().Find(x => x.name == "Wet");
        if (!wet) return;
        if (WorldGenerator.instance.GetBiome(__instance.m_character.position()) != Heightmap.Biome.AshLands) return;
        if (wet.m_ttl > maxTtl.Value) wet.m_ttl = maxTtl.Value;
        if (!removeWet.Value) return;
        __instance.RemoveStatusEffect(wet);
    }

    [HarmonyPatch(typeof(SEMan), nameof(SEMan.AddStatusEffect),
        [typeof(StatusEffect), typeof(bool), typeof(int), typeof(float)])]
    [HarmonyPrefix]
    public static bool DoNotAdd(SEMan __instance, StatusEffect statusEffect)    
    {   
        if (!removeWet.Value) return true;
        if (statusEffect.name != "Wet") return true;
        if (WorldGenerator.instance.GetBiome(__instance.m_character.position()) != Heightmap.Biome.AshLands)
            return true;
        return false;
    }
}