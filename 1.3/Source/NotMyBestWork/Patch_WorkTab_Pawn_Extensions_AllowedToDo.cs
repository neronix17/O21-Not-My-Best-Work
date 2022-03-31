using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace NotMyBestWork
{
	[HarmonyPatch]
	public static class Patch_WorkTab_Pawn_Extensions_AllowedToDo
	{
		public static MethodBase target;

		public static bool Prepare()
		{
			ModContentPack modContentPack = LoadedModManager.RunningMods.FirstOrDefault((ModContentPack m) => m.Name == "Work Tab");
			if (modContentPack == null)
			{
				return false;
			}
			Type type = modContentPack.assemblies.loadedAssemblies.FirstOrDefault((Assembly a) => a.GetName().Name == "WorkTab").GetType("WorkTab.Pawn_Extensions");
			if (type == null)
			{
				Log.Warning(":: Not My Best Work :: Can't patch WorkTab; no Pawn_Extensions found!");
				return false;
			}
			target = AccessTools.DeclaredMethod(type, "AllowedToDo", (Type[])null, (Type[])null);
			if (target == null)
			{
				Log.Warning(":: Not My Best Work :: Can't patch WorkTab; no Pawn_Extensions.AllowedToDo found!");
				return false;
			}
			return true;
		}

		public static MethodBase TargetMethod()
		{
			return target;
		}

		[HarmonyPostfix]
		public static void Postfix(ref bool __result)
		{
			__result = true;
		}
	}
}
