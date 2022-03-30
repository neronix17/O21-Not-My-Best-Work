﻿using HarmonyLib;
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
	[HarmonyPatch(typeof(WidgetsWork), "TipForPawnWorker")]
	public static class WidgetsWork_TipForPawnWorker
	{
		public static bool Prefix(Pawn p, WorkTypeDef wDef, ref string __result)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(wDef.gerundLabel.CapitalizeFirst());
			if (p.WorkTypeIsDisabled(wDef))
			{
                stringBuilder.Append("NotMyBestWork.CannotDoThisWork".Translate(p.LabelShort));
				__result = stringBuilder.ToString();
				return false;
			}
			return true;
		}
	}
}