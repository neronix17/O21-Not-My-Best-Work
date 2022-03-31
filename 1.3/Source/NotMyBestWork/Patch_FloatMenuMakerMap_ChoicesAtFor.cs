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
	[HarmonyPatch(typeof(FloatMenuMakerMap), "ChoicesAtFor")]
	public static class Patch_FloatMenuMakerMap_ChoicesAtFor
	{
		public static bool skip;

		[HarmonyPriority(100)]
		public static void Prefix()
		{
			skip = true;
		}

		[HarmonyPriority(700)]
		public static void Postfix()
		{
			skip = false;
		}
	}
}
