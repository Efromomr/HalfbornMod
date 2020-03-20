using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Stones
{

    public class BlueStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Blue Stone");
            this.Tooltip.SetDefault("The voice of water speaks to you... ");
        }

        public override void SetDefaults()
        {
            this.item.width = 24;
            this.item.height = 24;
            this.item.value = 6000;
            this.item.rare = 1;

        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(null, "BlueShard", 5);
            modRecipe.AddTile(TileID.Anvils);
            modRecipe.SetResult((ModItem)this, 1);
            modRecipe.AddRecipe();
        }


    }
}
