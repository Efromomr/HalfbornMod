using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Gloves
{

    public class GreenGlove : JewelGlove
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Green Glove");
            this.Tooltip.SetDefault("This glove will let you use the power of Life and Nature. ");
        }

        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().greenGlove = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "GreenStone";
            return str;
        }


    }
}
