using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Stones
{

    public class YellowStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Yellow Stone");
            this.Tooltip.SetDefault("This stone is as hard as glass. ");
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
            modRecipe.AddIngredient(null, "YellowShard", 5);
            modRecipe.AddTile(TileID.Anvils);
            modRecipe.SetResult((ModItem)this, 1);
            modRecipe.AddRecipe();
        }


    }
}
