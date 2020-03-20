using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Gloves
{

    public class WhiteGlove : JewelGlove
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("White Glove");
            this.Tooltip.SetDefault("This glove will let you use the power of Life and Light. ");
        }

        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().whiteGlove = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "WhiteStone";
            return str;
        }


    }
}
