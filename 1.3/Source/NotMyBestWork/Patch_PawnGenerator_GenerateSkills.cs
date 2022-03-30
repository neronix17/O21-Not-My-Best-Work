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
	[HarmonyPatch(typeof(PawnGenerator), "GenerateSkills")]
	public static class PawnGenerator_GenerateSkills
	{
		private static void Postfix(Pawn pawn)
		{
			if (IsTagDisabled(pawn, WorkTags.Animals))
			{
				Flatten(pawn, SkillDefOf.Animals);
			}
			if (IsTagDisabled(pawn, WorkTags.Artistic))
			{
				Flatten(pawn, SkillDefOf.Artistic);
			}
			if (IsTagDisabled(pawn, WorkTags.Caring))
			{
				Flatten(pawn, SkillDefOf.Medicine);
			}
			if (IsTagDisabled(pawn, WorkTags.Cooking))
			{
				Flatten(pawn, SkillDefOf.Cooking);
			}
			if (IsTagDisabled(pawn, WorkTags.Crafting))
			{
				Flatten(pawn, SkillDefOf.Crafting);
			}
			if (IsTagDisabled(pawn, WorkTags.Intellectual))
			{
				Flatten(pawn, SkillDefOf.Intellectual);
			}
			if (IsTagDisabled(pawn, WorkTags.ManualSkilled))
			{
				Flatten(pawn, SkillDefOf.Construction);
				Flatten(pawn, SkillDefOf.Cooking);
				Flatten(pawn, SkillDefOf.Crafting);
				Flatten(pawn, SkillDefOf.Plants);
				Flatten(pawn, SkillDefOf.Mining);
			}
			if (IsTagDisabled(pawn, WorkTags.Mining))
			{
				Flatten(pawn, SkillDefOf.Mining);
			}
			if (IsTagDisabled(pawn, WorkTags.PlantWork))
			{
				Flatten(pawn, SkillDefOf.Plants);
			}
			if (IsTagDisabled(pawn, WorkTags.Social))
			{
				Flatten(pawn, SkillDefOf.Social);
			}
			if (IsTagDisabled(pawn, WorkTags.Violent))
			{
				Flatten(pawn, SkillDefOf.Melee);
				Flatten(pawn, SkillDefOf.Shooting);
			}
		}

		private static bool IsTagDisabled(Pawn pawn, WorkTags workTag)
		{
			return (pawn.CombinedDisabledWorkTags & workTag) != 0;
		}

		private static void Flatten(Pawn pawn, SkillDef skill)
		{
			pawn.skills.GetSkill(skill).Level = NotMyBestWorkMod.settings.normalLevelLimit;
		}
	}
}
