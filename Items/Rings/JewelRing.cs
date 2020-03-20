using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Rings
{
    public abstract class JewelRing : JewelAccessory
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 6100;
            item.rare = 1;
            item.accessory = true;
        }

        public virtual string SafeAddRecipes ()
        {
            string str = "";
            return str;
        }
        public sealed override void AddRecipes()
        {
            string ing;
            ing = SafeAddRecipes();
 
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.anyIronBar = true;
            modRecipe.AddIngredient(ItemID.IronBar, 1);
            modRecipe.AddIngredient(null, ing, 1);
            modRecipe.AddTile(TileID.Anvils);
            modRecipe.SetResult(this);
            modRecipe.AddRecipe();
        }
    }

}