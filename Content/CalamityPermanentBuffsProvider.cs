using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BossLoadouts.Content.UI;
using static BossLoadouts.Content.UI.PermanentBuffsEditorUI;
using Terraria;
using CalamityMod;
using Terraria.ModLoader;
using CalamityMod.Items.PermanentBoosters;

namespace CalamityBossLoadouts.Content
{
    class CalamityPermanentBuffsProvider : IPermanentBuffProvider
    {
        public IEnumerable<PermanentBuffEntry> GetBuffEntries()
        {
            Player player = Main.LocalPlayer;
            var modPlayer = player.Calamity();

            return new List<PermanentBuffEntry>()
            {
                new PermanentBuffEntry()
                {
                    Name = "Mushroom Plasma Root",
                    SortIndex = 5,
                    IsUnlocked = () => modPlayer.rageBoostOne,
                    SetUnlocked = val =>
                    {
                        modPlayer.rageBoostOne = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Electrolye Gel Pack",
                    SortIndex = 15,
                    IsUnlocked = () => modPlayer.adrenalineBoostOne,
                    SetUnlocked = val =>
                    {
                        modPlayer.adrenalineBoostOne = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Comet Shard",
                    SortIndex = 30,
                    IsUnlocked = () => modPlayer.cShard,
                    SetUnlocked = val =>
                    {
                        modPlayer.cShard = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Sanguine Tangerine",
                    SortIndex = 40,
                    IsUnlocked = () => modPlayer.sTangerine,
                    SetUnlocked = val =>
                    {
                        modPlayer.sTangerine = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Miracle Fruit",
                    SortIndex = 50,
                    IsUnlocked = () => modPlayer.mFruit,
                    SetUnlocked = val =>
                    {
                        modPlayer.mFruit = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Starlight Fuel Cell",
                    SortIndex = 60,
                    IsUnlocked = () => modPlayer.adrenalineBoostTwo,
                    SetUnlocked = val =>
                    {
                        modPlayer.adrenalineBoostTwo = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Infernal Blood",
                    SortIndex = 70,
                    IsUnlocked = () => modPlayer.rageBoostTwo,
                    SetUnlocked = val =>
                    {
                        modPlayer.rageBoostTwo = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Ethereal Core",
                    SortIndex = 80,
                    IsUnlocked = () => modPlayer.eCore,
                    SetUnlocked = val =>
                    {
                        modPlayer.eCore = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Celestial Onion",
                    SortIndex = 90,
                    IsUnlocked = () => modPlayer.extraAccessoryML,
                    SetUnlocked = val =>
                    {
                        if(val && !modPlayer.extraAccessoryML)
                        {
                            modPlayer.extraAccessoryML = true;
                            player.extraAccessorySlots++;
                        }
                        else if(!val && modPlayer.extraAccessoryML)
                        {
                            modPlayer.extraAccessoryML = false;
                            player.extraAccessorySlots = player.extraAccessorySlots == 0 ? 0 : player.extraAccessorySlots - 1;
                        }
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Red Lightning Container",
                    SortIndex = 100,
                    IsUnlocked = () => modPlayer.rageBoostThree,
                    SetUnlocked = val =>
                    {
                        modPlayer.rageBoostThree = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Tainted Cloudberry",
                    SortIndex = 110,
                    IsUnlocked = () => modPlayer.tCloudberry,
                    SetUnlocked = val =>
                    {
                        modPlayer.tCloudberry = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Phantom Heart",
                    SortIndex = 120,
                    IsUnlocked = () => modPlayer.pHeart,
                    SetUnlocked = val =>
                    {
                        modPlayer.pHeart = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Ectoheart",
                    SortIndex = 130,
                    IsUnlocked = () => modPlayer.adrenalineBoostThree,
                    SetUnlocked = val =>
                    {
                        modPlayer.adrenalineBoostThree = val;
                    }
                },
                new PermanentBuffEntry()
                {
                    Name = "Sacred Strawberry",
                    SortIndex = 140,
                    IsUnlocked = () => modPlayer.sStrawberry,
                    SetUnlocked = val =>
                    {
                        modPlayer.sStrawberry = val;
                    }
                },
            };
        }
    }
}
