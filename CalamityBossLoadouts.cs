using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using CalamityMod;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader.UI;
using Terraria;
using CalamityBossLoadouts.Content;

namespace CalamityBossLoadouts
{
	public class CalamityBossLoadouts : Mod
	{
        public override void PostSetupContent()
        {
            // Find the main mod and its UI
            ModLoader.TryGetMod("BossLoadouts", out var mainMod);
            if (mainMod == null) return;

            BossLoadouts.BossLoadouts.BossProviders.Add(new CalamityBossProvider());
            BossLoadouts.BossLoadouts.BuffProviders.Add(new CalamityPermanentBuffsProvider());
            BossLoadouts.Content.UI.PermanentBuffsEditorUI.OnInjectExtraButtons.Add(AddShroomedButtons);
        }

        public static UITextPanel<string> shroomedToggleButton;
        public static UITextPanel<string> shroomedLevelDisplay;
        public static UITextPanel<string> shroomedLevelUpButton;
        public static UITextPanel<string> shroomedLevelDownButton;

        private void AddShroomedButtons(UIPanel mainPanel)
        {
            // Toggle button
            shroomedToggleButton = new UITextPanel<string>("Shroomed: OFF")
            {
                HAlign = 0.01f,
                VAlign = 0.2f,
                Width = { Pixels = 250 },
                Height = { Pixels = 30 },
            };
            shroomedToggleButton.OnLeftClick += (evt, element) =>
            {
                Player player = Main.LocalPlayer;
                var modPlayer = player.Calamity();
                Terraria.Audio.SoundEngine.PlaySound(SoundID.MenuTick);

                if (modPlayer.trippy)
                {
                    SetShroomedLevel(0);
                }
                else
                {
                    SetShroomedLevel(1);
                }
                UpdateShroomedUI();
            };
            mainPanel.Append(shroomedToggleButton);

            // Level display
            shroomedLevelDisplay = new UITextPanel<string>("Level: OFF")
            {
                HAlign = 0.82f,
                VAlign = 0.2f,
                Width = { Pixels = 110 },
                Height = { Pixels = 30 },
                BackgroundColor = Color.Gray
            };
            mainPanel.Append(shroomedLevelDisplay);

            // Level Down Button ▼
            shroomedLevelDownButton = new UITextPanel<string>("▼")
            {
                HAlign = 0.59f,
                VAlign = 0.2f,
                Width = { Pixels = 25 },
                Height = { Pixels = 30 },
            };
            shroomedLevelDownButton.WithFadedMouseOver();
            shroomedLevelDownButton.OnLeftClick += (evt, element) =>
            {
                Player player = Main.LocalPlayer;
                var modPlayer = player.Calamity();

                /*if (modPlayer.trippyLevel > 1)
                {
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.MenuTick);
                    SetShroomedLevel(modPlayer.trippyLevel - 1);
                    UpdateShroomedUI();
                }*/
            };
            mainPanel.Append(shroomedLevelDownButton);

            // Level Up Button ▲
            shroomedLevelUpButton = new UITextPanel<string>("▲")
            {
                HAlign = 0.95f,
                VAlign = 0.2f,
                Width = { Pixels = 25 },
                Height = { Pixels = 30 },
            };
            shroomedLevelUpButton.WithFadedMouseOver();
            shroomedLevelUpButton.OnLeftClick += (evt, element) =>
            {
                Player player = Main.LocalPlayer;
                var modPlayer = player.Calamity();

                /*if (modPlayer.trippyLevel < 3)
                {
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.MenuTick);
                    SetShroomedLevel(modPlayer.trippyLevel + 1);
                    UpdateShroomedUI();
                }*/
            };
            mainPanel.Append(shroomedLevelUpButton);

            // Initial UI update
            UpdateShroomedUI();
        }

        private void SetShroomedLevel(int level)
        {
            Player player = Main.LocalPlayer;
            var modPlayer = player.Calamity();

            level = Math.Clamp(level, 0, 3);
            //modPlayer.trippyLevel = level;

            if (level > 0)
            {
                if (!player.HasBuff<CalamityMod.Buffs.Alcohol.Trippy>())
                    player.AddBuff(ModContent.BuffType<CalamityMod.Buffs.Alcohol.Trippy>(), int.MaxValue);
                modPlayer.trippy = true;
            }
            else
            {
                player.ClearBuff(ModContent.BuffType<CalamityMod.Buffs.Alcohol.Trippy>());
                modPlayer.trippy = false;
            }
        }

        private void UpdateShroomedUI()
        {
            Player player = Main.LocalPlayer;
            var modPlayer = player.Calamity();
            if (modPlayer == null) return;

            bool isActive = modPlayer.trippy;

            if (shroomedToggleButton != null)
            {
                shroomedToggleButton.SetText(isActive ? "Shroomed: ON" : "Shroomed: OFF");
                shroomedToggleButton.BackgroundColor = isActive ? Color.Green : Color.Red;
                shroomedToggleButton.WithFadedMouseOver(
                    isActive ? Color.DarkGreen : Color.DarkRed,
                    isActive ? Color.Green : Color.Red);
            }

            if (shroomedLevelDisplay != null)
            {
                shroomedLevelDisplay.SetText(isActive ? $"Level: ONE" : "Level: OFF");
                shroomedLevelDisplay.BackgroundColor = isActive ? Color.LightGray : Color.Gray;
            }

            if (shroomedLevelUpButton != null && false)
            {
                /*shroomedLevelUpButton.BackgroundColor = (isActive && modPlayer.trippyLevel < 3) ?
                    Color.LightBlue : Color.Gray;
                shroomedLevelUpButton.WithFadedMouseOver(
                    (isActive && modPlayer.trippyLevel < 3) ? Color.LightBlue : Color.Gray,
                    (isActive && modPlayer.trippyLevel < 3) ? Color.LightBlue : Color.Gray);*/
            }

            if (shroomedLevelDownButton != null && false)
            {
                /*shroomedLevelDownButton.BackgroundColor = (isActive && modPlayer.trippyLevel > 1) ?
                    Color.LightBlue : Color.Gray;
                shroomedLevelDownButton.WithFadedMouseOver(
                    (isActive && modPlayer.trippyLevel > 1) ? Color.LightBlue : Color.Gray,
                    (isActive && modPlayer.trippyLevel > 1) ? Color.LightBlue : Color.Gray);*/
            }
        }

    }
}
