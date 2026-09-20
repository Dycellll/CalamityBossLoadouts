using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BossLoadouts.Systems;
using CalamityMod.Buffs.Alcohol;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria;
using CalamityMod;
using Microsoft.Xna.Framework;
using CalamityMod.CalPlayer;

namespace CalamityBossLoadouts.Content
{
    class SaveLoadPlayer : ModPlayer
    {
        private int savedShroomLevel = 0;
        private bool reTrippy = false;
        public override void SaveData(TagCompound tag)
        {
            var modPlayer = Player.Calamity();
            if (!modPlayer.trippy)
            {
                tag["shroomedLevel"] = 0;
            }
            else
            {
                tag["shroomedLevel"] = 1;
            }
        }

        public override void LoadData(TagCompound tag)
        {
            savedShroomLevel = 0;
            reTrippy = false;
            if (tag.ContainsKey("shroomedLevel"))
            {
                int level = tag.GetInt("shroomedLevel");
                var modPlayer = Player.Calamity();

                if (level > 0)
                {
                    modPlayer.trippy = level > 0;
                }
                else
                {
                    modPlayer.trippy = false;
                    if (Player.HasBuff<Trippy>())
                    {
                        Player.ClearBuff(ModContent.BuffType<Trippy>());
                    }
                }
            }
            else if (tag.ContainsKey("shroomed"))
            {
                int level = tag.GetInt("shroomed");
                var modPlayer = Player.Calamity();
                if (level > 0)
                {
                    modPlayer.trippy = level > 0;
                }
                else
                {
                    modPlayer.trippy = false;
                    if (Player.HasBuff<Trippy>())
                    {
                        Player.ClearBuff(ModContent.BuffType<Trippy>());
                    }
                }
            }
        }

        public override void OnEnterWorld()
        {
            var modPlayer = Player.Calamity();

            if (modPlayer.trippy)
            {
                Player.AddBuff(ModContent.BuffType<Trippy>(), int.MaxValue);
            }
            else
            {
                if (Player.HasBuff<Trippy>())
                {
                    Player.ClearBuff(ModContent.BuffType<Trippy>());
                }
                modPlayer.trippy = false;
            }
        }

        public override void PostUpdateBuffs()
        {
            var modPlayer = Player.Calamity();
            BossLoadoutsSystem loadoutsSystem = ModContent.GetInstance<BossLoadoutsSystem>();

            if (loadoutsSystem.BuffsEditorUI == null || CalamityBossLoadouts.shroomedToggleButton == null)
                return;

            if (modPlayer.trippy && (CalamityBossLoadouts.shroomedToggleButton.BackgroundColor == Color.Green || CalamityBossLoadouts.shroomedToggleButton.BackgroundColor == Color.DarkGreen))
            {
                if (!Player.HasBuff<Trippy>())
                {
                    Player.AddBuff(ModContent.BuffType<Trippy>(), 60);
                }
                modPlayer.trippy = true;
            }
            else
            {
                if (Player.HasBuff<Trippy>())
                {
                    Player.ClearBuff(ModContent.BuffType<Trippy>());
                }
                modPlayer.trippy = false;
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust, ref PlayerDeathReason damageSource)
        {
            var modPlayer = Player.Calamity();
            savedShroomLevel = modPlayer.trippy ? 1 : 0;

            bool toggleOn = CalamityBossLoadouts.shroomedToggleButton != null &&
                            (CalamityBossLoadouts.shroomedToggleButton.BackgroundColor == Color.Green ||
                             CalamityBossLoadouts.shroomedToggleButton.BackgroundColor == Color.DarkGreen);

            reTrippy = savedShroomLevel > 0 && toggleOn;
            return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genDust, ref damageSource);
        }

        public override void OnRespawn()
        {
            var modPlayer = Player.Calamity();
            modPlayer.trippy = savedShroomLevel > 0;

            bool toggleOn = CalamityBossLoadouts.shroomedToggleButton != null &&
                            (CalamityBossLoadouts.shroomedToggleButton.BackgroundColor == Color.Green ||
                             CalamityBossLoadouts.shroomedToggleButton.BackgroundColor == Color.DarkGreen);

            if (reTrippy && toggleOn)
            {
                Player.AddBuff(ModContent.BuffType<Trippy>(), int.MaxValue);
                modPlayer.trippy = true;
            }
        }
    }
}
