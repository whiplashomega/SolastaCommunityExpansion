﻿using ModKit;
using SolastaCommunityExpansion.Models;
using static SolastaCommunityExpansion.Viewers.Displays.Shared;

namespace SolastaCommunityExpansion.Viewers.Displays
{
    internal static class RulesDisplay
    {
        internal static void DisplayRules()
        {
            int intValue;
            bool toggle;

            UI.Label("");

            toggle = Main.Settings.DisplaySrdRulesToggle;
            if (UI.DisclosureToggle("SRD:".yellow(), ref toggle, 200))
            {
                Main.Settings.DisplaySrdRulesToggle = toggle;
            }

            if (Main.Settings.DisplaySrdRulesToggle)
            {
                UI.Label("");

                toggle = Main.Settings.UseOfficialAdvantageDisadvantageRules;
                if (UI.Toggle("Use official advantage / disadvantage rules", ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.UseOfficialAdvantageDisadvantageRules = toggle;
                }

                toggle = Main.Settings.UseOfficialCombatSurpriseRules;
                if (UI.Toggle("Use official combat surprise rules", ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.UseOfficialCombatSurpriseRules = toggle;
                    Main.Settings.RollDifferentStealthChecksForEachCharacterPair = toggle; // makes many rolls default
                }

                if (Main.Settings.UseOfficialCombatSurpriseRules)
                {
                    toggle = Main.Settings.RollDifferentStealthChecksForEachCharacterPair;
                    if (UI.Toggle("+ Roll different ".italic() + "Stealth".italic().orange() + " checks for each surprised / surprising character pairs".italic(), ref toggle, UI.AutoWidth()))
                    {
                        Main.Settings.RollDifferentStealthChecksForEachCharacterPair = toggle;
                    }
                }

                UI.Label("");

                toggle = Main.Settings.AddBleedingToLesserRestoration;
                if (UI.Toggle("Add the " + "Bleeding".orange() + " condition to the conditions removed by " + "Greater and Lesser Restoration".orange(), ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.AddBleedingToLesserRestoration = toggle;
                }

                toggle = Main.Settings.BlindedConditionDontAllowAttackOfOpportunity;
                if (UI.Toggle("Blinded".orange() + " condition doesn't allow attack of opportunity", ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.BlindedConditionDontAllowAttackOfOpportunity = toggle;
                    SrdAndHouseRulesContext.ApplyConditionBlindedShouldNotAllowOpportunityAttack();
                }

                UI.Label("");

                toggle = Main.Settings.AllowTargetingSelectionWhenCastingChainLightningSpell;
                if (UI.Toggle("Allow target selection when casting the " + "Chain Lightning".orange() + " spell", ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.AllowTargetingSelectionWhenCastingChainLightningSpell = toggle;
                    SrdAndHouseRulesContext.AllowTargetingSelectionWhenCastingChainLightningSpell();
                }

                toggle = Main.Settings.FixSorcererTwinnedLogic;
                if (UI.Toggle("Fix " + "Sorcerer".orange() + " twinned metamagic use " + "[a spell must be incapable of targeting more than one creature at the spell's current level]".italic().yellow(), ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.FixSorcererTwinnedLogic = toggle;
                }

                toggle = Main.Settings.FullyControlConjurations;
                if (UI.Toggle("Fully control conjurations " + "[animals, elementals, etc]".italic().yellow(), ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.FullyControlConjurations = toggle;
                    Main.Settings.DismissControlledConjurationsWhenDeliberatelyDropConcentration = false;
                    ConjurationsContext.Load();
                }

                if (Main.Settings.FullyControlConjurations)
                {
                    toggle = Main.Settings.DismissControlledConjurationsWhenDeliberatelyDropConcentration;
                    if (UI.Toggle("+ Dismiss fully controlled conjurations when deliberately dropping concentration".italic(), ref toggle, UI.AutoWidth()))
                    {
                        Main.Settings.DismissControlledConjurationsWhenDeliberatelyDropConcentration = toggle;
                    }
                }
            }

            UI.Label("");

            toggle = Main.Settings.DisplayHouseRulesToggle;
            if (UI.DisclosureToggle("House:".yellow(), ref toggle, 200))
            {
                Main.Settings.DisplayHouseRulesToggle = toggle;
            }

            if (Main.Settings.DisplayHouseRulesToggle)
            {
                UI.Label("");

                toggle = Main.Settings.AllowAnyClassToWearSylvanArmor;
                if (UI.Toggle("Allow any class to wear sylvan armor", ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.AllowAnyClassToWearSylvanArmor = toggle;
                    ItemOptionsContext.SwitchUniversalSylvanArmor();
                }

                toggle = Main.Settings.AllowDruidToWearMetalArmor;
                if (UI.Toggle("Allow " + "Druid".orange() + " to wear metal armor", ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.AllowDruidToWearMetalArmor = toggle;
                    DruidArmorContext.Switch(toggle);
                }

                toggle = Main.Settings.DisableAutoEquip;
                if (UI.Toggle("Disable auto-equip of items in inventory", ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.DisableAutoEquip = toggle;
                }

                toggle = Main.Settings.MakeAllMagicStaveArcaneFoci;
                if (UI.Toggle("Make all magic staves arcane foci " + "[except for ".italic().yellow() + "Staff of Healing".italic().orange() + " which is Universal]".italic().yellow(), ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.MakeAllMagicStaveArcaneFoci = toggle;
                    ItemOptionsContext.SwitchMagicStaffFoci();
                }

                UI.Label("");

                toggle = Main.Settings.IncreaseSenseNormalVision;
                if (UI.Toggle("Increase " + "Sense Normal Vision".orange() + " range to enable long range attacks " + RequiresRestart, ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.IncreaseSenseNormalVision = toggle;
                }

                UI.Label("");

                toggle = Main.Settings.QuickCastLightCantripOnWornItemsFirst;
                if (UI.Toggle("Quick cast light cantrip uses head or torso worn items first", ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.QuickCastLightCantripOnWornItemsFirst = toggle;
                }

                UI.Label("");

                toggle = Main.Settings.AddPickpocketableLoot;
                if (UI.Toggle("Add pickpocketable loot " + "[suggested if ".italic().yellow() + "Pickpocket".italic().orange() + " feat is enabled]".italic().yellow(), ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.AddPickpocketableLoot = toggle;
                    if (toggle)
                    {
                        PickPocketContext.Load();
                    }
                }

                toggle = Main.Settings.AllowStackedMaterialComponent;
                if (UI.Toggle("Allow stacked material component " + "[e.g. 2x500gp diamond is equivalent to 1000gp diamond]".italic().yellow(), ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.AllowStackedMaterialComponent = toggle;
                }

                toggle = Main.Settings.ScaleMerchantPricesCorrectly;
                if (UI.Toggle("Scale merchant prices correctly / exactly", ref toggle, UI.AutoWidth()))
                {
                    Main.Settings.ScaleMerchantPricesCorrectly = toggle;
                }

                UI.Label("");

                intValue = Main.Settings.MultiplyTheExperienceGainedBy;
                if (UI.Slider("Multiply the experience gained by ".white() + "[%]".red(), ref intValue, 0, 200, 100, "", UI.Width(100)))
                {
                    Main.Settings.MultiplyTheExperienceGainedBy = intValue;
                }
            }

            UI.Label("");
        }
    }
}
