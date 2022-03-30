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
	[HarmonyPatch(typeof(CharacterCardUtility), "DrawCharacterCard")]
	public static class Patch_CharacterCardUtility_DrawCharacterCard
	{
		private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			List<CodeInstruction> list = new List<CodeInstruction>(instructions);
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i].operand as string;
				if (text == "IncapableOf")
				{
					list[i].operand = "NotMyBestWork.IncapableOf";
				}
			}
			return list;
		}
	}
}
