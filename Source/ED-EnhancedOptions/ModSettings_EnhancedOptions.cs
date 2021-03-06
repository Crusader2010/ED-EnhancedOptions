﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace EnhancedDevelopment.EnhancedOptions
{
    class ModSettings_EnhancedOptions : ModSettings
    {

        public bool ShowLettersThreatBig = true;
        public bool ShowLettersThreatSmall = true;
        public bool ShowLettersNegativeEvent = true;
        public bool ShowLettersNeutralEvent = true;
        public bool ShowLettersPositiveEvent = true;
        public bool ShowLettersItemStashFeeDemand = true;

        public bool LetterNamesToSuppressEnabled = false;
        public string LetterNamesToSuppress = String.Empty;

        public bool Plant24HEnabled = false;
        public bool PlantLights24HEnabled = false;

        public bool SafeTrapEnabled = false;
        public bool TurretControlEnabled = false;
        public bool HidePowerConnections = false;

        public bool SuppressBreakdown = false;
        public bool LockDevMode = false;
        public bool Speed4WithoutDev = false;
        public bool SuppressCombatSlowdown = false;
        public bool HideSpots = false;

        /// <summary>
        /// DrawSize of the Blight, Default 1
        /// </summary>
        public float BlightScale = 1;

        /// <summary>
        /// Number of the Image to use for the Blight
        /// 
        /// 0 = Default
        /// 1 = Red
        /// 2 = Blue
        /// 3 = Orange
        /// 4 = Purple
        /// 
        /// </summary>
        public int BlightImageIndex = 0;
        
        public bool SuppressStrippingCremationCorps = false;


        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look<bool>(ref ShowLettersThreatBig, "ShowLettersThreatBig", true, true);
            Scribe_Values.Look<bool>(ref ShowLettersThreatSmall, "ShowLettersThreatSmall", true, true);
            Scribe_Values.Look<bool>(ref ShowLettersNegativeEvent, "ShowLettersNegativeEvent", true, true);
            Scribe_Values.Look<bool>(ref ShowLettersNeutralEvent, "ShowLettersNeutralEvent", true, true);
            Scribe_Values.Look<bool>(ref ShowLettersPositiveEvent, "ShowLettersPositiveEvent", true, true);
            Scribe_Values.Look<bool>(ref ShowLettersItemStashFeeDemand, "ShowLettersItemStashFeeDemand", true, true);
            Scribe_Values.Look<bool>(ref LetterNamesToSuppressEnabled, "LetterNamesToSuppressEnabled", false, true);
            Scribe_Values.Look<string>(ref LetterNamesToSuppress, "LetterNamesToSuppress", String.Empty, true);

            Scribe_Values.Look<bool>(ref Plant24HEnabled, "Plant24HEnabled", false, true);
            Scribe_Values.Look<bool>(ref PlantLights24HEnabled, "PlantLights24HEnabled", Plant24HEnabled, true); //If Not Set Default to Plant24HEnabled for backwards compatibility.
            Scribe_Values.Look<bool>(ref SafeTrapEnabled, "SafeTrapEnabled", false, true);
            Scribe_Values.Look<bool>(ref TurretControlEnabled, "TurretControlEnabled", false, true);
            Scribe_Values.Look<bool>(ref HidePowerConnections, "HidePowerConnections", false, true);
            Scribe_Values.Look<bool>(ref SuppressBreakdown, "SuppressBreakdown", false, true);
            Scribe_Values.Look<bool>(ref LockDevMode, "LockDevMode", false, true);
            Scribe_Values.Look<bool>(ref Speed4WithoutDev, "Speed4WithoutDev", false, true);
            Scribe_Values.Look<bool>(ref SuppressCombatSlowdown, "SuppressCombatSlowdown", false, true);
                        
            Scribe_Values.Look<float>(ref BlightScale, "BlightScale", 1, true);
            Scribe_Values.Look<int>(ref BlightImageIndex, "BlightImageIndex", 0, true);

            Scribe_Values.Look<bool>(ref SuppressStrippingCremationCorps, "SuppressStrippingCremationCorps", false, true);
            Scribe_Values.Look<bool>(ref HideSpots, "HideSpots", false, true);
        }


        public void DoSettingsWindowContents(Rect canvas)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.ColumnWidth = 250f;
            listing_Standard.Begin(canvas);
            //listing_Standard.set_ColumnWidth(rect.get_width() - 4f);

            listing_Standard.Label("Sections Starting with '*' only apply after Restart.");
            listing_Standard.GapLine(12f);
            listing_Standard.Label("Letter Suppression:");
            listing_Standard.Gap(12f);
            listing_Standard.CheckboxLabeled("Show ThreatBig", ref ShowLettersThreatBig, "True if you want to See Any ThreatBig Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.CheckboxLabeled("Show ThreatSmall", ref ShowLettersThreatSmall, "True if you want to See Any ThreatSmall Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.CheckboxLabeled("Show NegativeEvent", ref ShowLettersNegativeEvent, "True if you want to See Any NegativeEvent Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.CheckboxLabeled("Show NeutralEvent", ref ShowLettersNeutralEvent, "True if you want to See Any NeutralEvent Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.CheckboxLabeled("Show PositiveEvent", ref ShowLettersPositiveEvent, "True if you want to See Any PositiveEvent Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.CheckboxLabeled("Show ItemStashFeeDemand", ref ShowLettersItemStashFeeDemand, "True if you want to See Any ItemStashFeeDemand Letters, False will Hide them. When a Letter is Shown its Name and Type will be written to the Log.");
            listing_Standard.Gap(12f);
            listing_Standard.CheckboxLabeled("Letter Names To Suppress Enabled", ref LetterNamesToSuppressEnabled, "True will Hide any Letters thats Name is in the following List, False to Ignore the List. List is Comma Separated. When a Letter is Shown its Name and Type will be written to the Log.");
            LetterNamesToSuppress = listing_Standard.TextEntry(LetterNamesToSuppress, 2);

            listing_Standard.GapLine(12f);

            listing_Standard.Label("* Plant 24H:");
            listing_Standard.CheckboxLabeled("Plant 24H", ref Plant24HEnabled, "Enable to allow Plants to Grow 24H a day.");
            listing_Standard.CheckboxLabeled("Plant Lights 24H", ref PlantLights24HEnabled, "Enable to allow SunLamps to Shine 24H a day.");
            listing_Standard.GapLine(12f);
            listing_Standard.Label("* Safe Trap Enabled:");
            listing_Standard.CheckboxLabeled("Safe Trap Enabled", ref SafeTrapEnabled, "Prevents Traps from triggering on your Colonists.");
            listing_Standard.GapLine(12f);
            listing_Standard.Label("* Turret Control Enabled:");
            listing_Standard.CheckboxLabeled("Turret Control Enabled", ref TurretControlEnabled, "Allows force attack commands to be given to turrets.");
            listing_Standard.GapLine(12f);
            listing_Standard.Label("* Hide Power Connections:");
            listing_Standard.CheckboxLabeled("Hide Power Connections", ref HidePowerConnections, "Hides the Small Power Connection Wires, Still show in Power overlay Mode.");
            listing_Standard.GapLine(12f);
            listing_Standard.Label("* Suppress Breakdown:");
            listing_Standard.CheckboxLabeled("Suppress Breakdown", ref SuppressBreakdown, "Suppress random Breakdowns, This was hard to test so please let me know if you have any issues.");
            listing_Standard.GapLine(12f);
            listing_Standard.Label("* Suppress LockDevMode:");
            listing_Standard.CheckboxLabeled("Suppress LockDevMode", ref LockDevMode, "Lock Dev Mode to its Current Selection.");
            listing_Standard.GapLine(12f);
            listing_Standard.Label("* Time Speed:");
            listing_Standard.CheckboxLabeled("Allow Speed4 Without Dev Mode", ref Speed4WithoutDev, "Allow Speed4 Without Dev Mode needing to be enabled, can be turned on by pressing '4'.");
            listing_Standard.CheckboxLabeled("Suppress Combat Slowdown", ref SuppressCombatSlowdown, "Suppress Limiting Speed in Combat.");
            
            listing_Standard.GapLine(12f);
            listing_Standard.Label("* Blight:");
            listing_Standard.Label("Blight Scale:  " + BlightScale);
            BlightScale = (float)Math.Round((Double)listing_Standard.Slider(BlightScale, 1, 10),1);
                        
            String _CurrentBlightImageDescription = string.Empty;
            switch (BlightImageIndex)
            {
                case 0:
                    _CurrentBlightImageDescription = "Default";
                    break;
                case 1:
                    _CurrentBlightImageDescription = "Red";
                    break;
                case 2:
                    _CurrentBlightImageDescription = "Blue";
                    break;
                case 3:
                    _CurrentBlightImageDescription = "Orange";
                    break;
                case 4:
                    _CurrentBlightImageDescription = "Purple";
                    break;
                default:
                    _CurrentBlightImageDescription = "Default";
                    break;
            }
            

            Rect _BlightSelection = listing_Standard.GetRect(30f);
            Widgets.Label(_BlightSelection.RightHalf(), _CurrentBlightImageDescription);
            if (Widgets.ButtonText(_BlightSelection.LeftHalf(), "Select Blight:"))
            {
                //Log.Error("Test");
                Find.WindowStack.Add(
                    new FloatMenu(new List<FloatMenuOption> {
                        new FloatMenuOption("Default (Green)", () => BlightImageIndex = 0),
                        new FloatMenuOption("Red", () => BlightImageIndex = 1),
                        new FloatMenuOption("Blue", () => BlightImageIndex = 2),
                        new FloatMenuOption("Orange", () => BlightImageIndex = 3),
                        new FloatMenuOption("Purple", () => BlightImageIndex = 4)
                    }));
            }

            listing_Standard.GapLine(12f);
            listing_Standard.Label("* Suppress Stripping Cremation Corps:");
            listing_Standard.CheckboxLabeled("SuppressStrippingCremationCorps", ref SuppressStrippingCremationCorps, "Stops Gear and Apparel from being removed from a Corps before Cremation, all gear will be lost.");

            listing_Standard.GapLine(12f);
            listing_Standard.Label("* Hide Spots:");
            listing_Standard.CheckboxLabeled("Hide Spots", ref HideSpots, "Stops Marriage, Caravan Packing and Party Spots from being show all the time. They will still show when Architect menu is open or one of the spots is the first thing selected. (Only checks when menu is changed)");
                        
            listing_Standard.End();
        }
    }
}
