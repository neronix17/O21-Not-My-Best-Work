using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using HarmonyLib;

namespace NotMyBestWork
{
    public class NotMyBestWorkMod : Mod
    {
        public static NotMyBestWorkMod mod;
        public static NotMyBestWorkSettings settings;

        public NotMyBestWorkMod(ModContentPack content) : base(content)
        {
            mod = this;
            settings = GetSettings<NotMyBestWorkSettings>();

            Harmony harmony = new Harmony("neronix17.notmybestwork.rimworld");
            harmony.PatchAll();

            Log.Message(":: Not My Best Work :: 1.0.0");
        }

        public override string SettingsCategory() => "Not My Best Work";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            {
                string normalLevelLimit_Buffer = settings.normalLevelLimit.ToString();
                listingStandard.TextFieldNumericLabeled("Base Level Limit", ref settings.normalLevelLimit, ref normalLevelLimit_Buffer);
            }
            {
                string minorPassionLimit_Buffer = settings.minorPassionLimit.ToString();
                listingStandard.TextFieldNumericLabeled("Minor Passion Limit", ref settings.minorPassionLimit, ref minorPassionLimit_Buffer);
            }
            {
                string majorPassionLimit_Buffer = settings.majorPassionLimit.ToString();
                listingStandard.TextFieldNumericLabeled("Major Passion Limit", ref settings.majorPassionLimit, ref majorPassionLimit_Buffer);
            }

            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
    }
}
