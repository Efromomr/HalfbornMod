using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Gloves
{

    public class BlackGlove : JewelGlove
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Black Glove");
            this.Tooltip.SetDefault("This glove will let you use the power of Death and Darkness. ");
        }

        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().blackGlove = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "BlackStone";
            return str;
        }


    }
}
