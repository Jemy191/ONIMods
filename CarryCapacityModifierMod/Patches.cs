using HarmonyLib;
using Klei.AI;
using PeterHan.PLib.Options;
using PeterHan.PLib.PatchManager;

namespace CarryCapacityModifierMod
{
	public class Patches
	{

		static Settings settings;
		
		[PLibMethod(RunAt.OnStartGame)]
		internal static void OnStartGame()
		{
			settings = POptions.ReadSettings<Settings>() ?? new Settings();
		}
		
		[HarmonyPatch(typeof(MinionIdentity))]
		[HarmonyPatch("ApplyCustomGameSettings")]
		public class MinionIdentity_ApplyCustomGameSettings_Patch
		{
			public static void Postfix(MinionIdentity __instance)
			{
				Db.Get().Attributes.CarryAmount.Lookup(__instance).Add(new AttributeModifier(Db.Get().Attributes.CarryAmount.Id, settings.CarryModifier / 100f, "Carry capacity modifier", true));
			}
		}
	}
}
