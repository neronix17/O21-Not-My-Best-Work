using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace NotMyBestWork
{
	[HarmonyPatch(typeof(FloatMenuMakerMap), "AddJobGiverWorkOrders")]
	public static class Patch_FloatMenuMakerMap_AddUndraftedOrders
	{
		[HarmonyTranspiler]
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			List<CodeInstruction> list = new List<CodeInstruction>(instructions);
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i].operand as string;
				if (text == "CannotPrioritizeWorkGiverDisabled")
				{
					list[i].operand = "NotMyBestWork.CannotPrioritizeWorkGiverDisabled";
				}
				if (text == "CannotPrioritizeNotAssignedToWorkType")
				{
					list[i].operand = "NotMyBestWork.CannotPrioritizeNotAssignedToWorkType";
				}
			}
			return list;
		}
	}
}
