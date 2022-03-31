using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace NotMyBestWork
{
	[HarmonyPatch(typeof(FloatMenuMakerMap), "AddHumanlikeOrders")]
	public static class Patch_FloatMenuMakerMap_AddHumanlikeOrders
	{
		[HarmonyTranspiler]
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			CodeMatcher codeMatcher = new CodeMatcher(instructions);
			int pos = codeMatcher.MatchForward(false, new CodeMatch(OpCodes.Ldstr, "CannotEquip", null)).Pos;
			int pos2 = codeMatcher.MatchForward(false, new CodeMatch(OpCodes.Br, null, null)).Pos;
			return codeMatcher.RemoveInstructionsInRange(pos, pos2).Instructions();
		}
	}
}
