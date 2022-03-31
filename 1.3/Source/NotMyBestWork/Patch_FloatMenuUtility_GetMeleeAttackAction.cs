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
	[HarmonyPatch(typeof(FloatMenuUtility), "GetMeleeAttackAction")]
	public static class FloatMenuUtility_GetMeleeAttackAction
	{
		[HarmonyTranspiler]
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			List<CodeInstruction> list = new List<CodeInstruction>(instructions);
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i].operand as string;
				if (text == "IsIncapableOfViolenceLower")
				{
					list[i].operand = "NotMyBestWork.IsIncapableOfViolenceLower";
				}
			}
			return list.AsEnumerable();
		}
	}
}
