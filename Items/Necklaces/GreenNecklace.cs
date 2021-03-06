﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Necklaces
{
    public class GreenNecklace : JewelNecklace
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Necklace");
            Tooltip.SetDefault("This necklace will let you use the power of Life and Nature. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().greenNecklace = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "GreenStone";
            return str;
        }
    }
}
