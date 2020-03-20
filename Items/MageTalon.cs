using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace HalfbornMod.Items
{

    public class MageTalon : ModItem
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mage's Talon");
            Tooltip.SetDefault("Awake a monster inside...");
        }

        
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item119;
            item.consumable = true;
        }
        public override bool UseItem(Player player)
        {          
            player.GetModPlayer<HalfbornPlayer>().mageDemon = true;
            
            if (player.GetModPlayer<HalfbornPlayer>().demonPower == 0)
            {
                player.GetModPlayer<HalfbornPlayer>().demonPower = 1;
            }
            player.GetModPlayer<HalfbornPlayer>().warDemon = false;
            player.GetModPlayer<HalfbornPlayer>().shootDemon = false;
            player.GetModPlayer<HalfbornPlayer>().summonDemon = false;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(null, "EmptyTalon", 1);
            modRecipe.AddTile(26);
            modRecipe.SetResult(this);
            modRecipe.AddRecipe();
        }
    }
}
