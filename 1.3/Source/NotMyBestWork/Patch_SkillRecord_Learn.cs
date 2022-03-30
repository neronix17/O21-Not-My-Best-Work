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
    [HarmonyPatch(typeof(SkillRecord), "Learn")]
    public class Patch_SkillRecord_Learn
    {
        [HarmonyPrefix]
        public static bool Prefix(float xp, bool direct, SkillRecord __instance)
        {
            Pawn pawn = __instance?.pawn;

            if (__instance.TotallyDisabled)
            {
                // Finds settings for limits.
                int levelLimit = 0;
                switch (__instance.passion)
                {
                    case Passion.None:
                        levelLimit = NotMyBestWorkMod.settings.normalLevelLimit;
                        break;
                    case Passion.Minor:
                        levelLimit = NotMyBestWorkMod.settings.minorPassionLimit;
                        break;
                    case Passion.Major:
                        levelLimit = NotMyBestWorkMod.settings.majorPassionLimit;
                        break;
                    default:
                        levelLimit = 20;
                        break;
                }

                if (__instance.levelInt >= levelLimit)
                {
                    // Prevents levelling up.
                    if (__instance.xpSinceLastLevel + xp > __instance.XpRequiredForLevelUp)
                    {
                        xp *= 0;
                    }
                }
            }
            return true;
        }
    }
}
