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
    public class NotMyBestWorkSettings : ModSettings
    {
        public int normalLevelLimit = 8;
        public int minorPassionLimit = 12;
        public int majorPassionLimit = 16;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref normalLevelLimit, "normalLevelLimit", 8);
            Scribe_Values.Look(ref minorPassionLimit, "minorPassionLimit", 12);
            Scribe_Values.Look(ref majorPassionLimit, "majorPassionLimit", 16);
        }
    }
}
