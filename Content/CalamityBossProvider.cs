using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BossLoadouts.Content.UI;
using Terraria;
using Terraria.ModLoader;
using static CalamityMod.DownedBossSystem;

namespace CalamityBossLoadouts.Content
{
    class CalamityBossProvider : BossDownedEditorUI.IBossProvider
    {
        public IEnumerable<BossDownedEditorUI.BossEntry> GetBossEntries()
        {
            return new List<BossDownedEditorUI.BossEntry>
        {
            new() { Name = "Desert Scourge", SortIndex = 10, IsDowned = () =>
                        downedDesertScourge, SetDowned = val =>
                        downedDesertScourge = val },
            new() { Name = "Crabulon", SortIndex = 30, IsDowned = () =>
                        downedCrabulon, SetDowned = val =>
                        downedCrabulon = val },
            new() { Name = "Hive Mind", SortIndex = 50, IsDowned = () =>
                        downedHiveMind, SetDowned = val =>
                        downedHiveMind = val },
            new() { Name = "Perforators", SortIndex = 51, IsDowned = () =>
                        downedPerforator, SetDowned = val =>
                        downedPerforator = val },
            new() { Name = "Slime God", SortIndex = 110, IsDowned = () =>
                        downedSlimeGod, SetDowned = val =>
                        downedSlimeGod = val },
            new() { Name = "Cryogen", SortIndex = 150, IsDowned = () =>
                        downedCryogen, SetDowned = val =>
                        downedCryogen = val },
            new() { Name = "Aquatic Scourge", SortIndex = 170, IsDowned = () =>
                        downedAquaticScourge, SetDowned = val =>
                        downedAquaticScourge = val },
            new() { Name = "Brimstone Elemental", SortIndex = 190, IsDowned = () =>
                        downedBrimstoneElemental, SetDowned = val =>
                        downedBrimstoneElemental = val },
            new() { Name = "Calamitas Clone", SortIndex = 210, IsDowned = () =>
                        downedCalamitasClone, SetDowned = val =>
                        downedCalamitasClone = val },
            new() { Name = "Astrum Aureus", SortIndex = 230, IsDowned = () =>
                        downedAstrumAureus, SetDowned = val =>
                        downedAstrumAureus = val },
            new() { Name = "Leviathan and Anahita", SortIndex = 235, IsDowned = () =>
                        downedLeviathan, SetDowned = val =>
                        downedLeviathan = val },
            new() { Name = "Plaguebringer Goliath", SortIndex = 290, IsDowned = () =>
                        downedPlaguebringer, SetDowned = val =>
                        downedPlaguebringer = val },
            new() { Name = "Ravager", SortIndex = 295, IsDowned = () =>
                        downedRavager, SetDowned = val =>
                        downedRavager = val },
            new() { Name = "Astrum Deus", SortIndex = 310, IsDowned = () =>
                        downedAstrumDeus, SetDowned = val =>
                        downedAstrumDeus = val },
            new() { Name = "Profaned Guardians", SortIndex = 340, IsDowned = () =>
                        downedGuardians, SetDowned = val =>
                        downedGuardians = val },
            new() { Name = "Dragonfolly", SortIndex = 360, IsDowned = () =>
                        downedDragonfolly, SetDowned = val =>
                        downedDragonfolly = val },
            new() { Name = "Providence", SortIndex = 380, IsDowned = () =>
                        downedProvidence, SetDowned = val =>
                        downedProvidence = val },
            new() { Name = "Signus", SortIndex = 400, IsDowned = () =>
                        downedSignus, SetDowned = val =>
                        downedSignus = val },
            new() { Name = "Storm Weaver", SortIndex = 420, IsDowned = () =>
                        downedStormWeaver, SetDowned = val =>
                        downedStormWeaver = val },
            new() { Name = "Ceaseless Void", SortIndex = 440, IsDowned = () =>
                        downedCeaselessVoid, SetDowned = val =>
                        downedCeaselessVoid = val },
            new() { Name = "Polterghast", SortIndex = 460, IsDowned = () =>
                        downedPolterghast, SetDowned = val =>
                        downedPolterghast = val },
            new() { Name = "OldDuke", SortIndex = 480, IsDowned = () =>
                        downedBoomerDuke, SetDowned = val =>
                        downedBoomerDuke = val },
            new() { Name = "Devourer of Gods", SortIndex = 500, IsDowned = () =>
                        downedDoG, SetDowned = val =>
                        downedDoG = val },
            new() { Name = "Yharon", SortIndex = 520, IsDowned = () =>
                        downedYharon, SetDowned = val =>
                        downedYharon = val },
            new() { Name = "Primordial Wyrm", SortIndex = 540, IsDowned = () =>
                        downedPrimordialWyrm, SetDowned = val =>
                        downedPrimordialWyrm = val },
            new() { Name = "Exo Mechs", SortIndex = 560, IsDowned = () =>
                        downedExoMechs, SetDowned = val =>
                        downedExoMechs = val },
            new() { Name = "Supreme Witch, Calamitas", SortIndex = 580, IsDowned = () =>
                        downedCalamitas, SetDowned = val =>
                        downedCalamitas = val },
        };
        }
    }
}
