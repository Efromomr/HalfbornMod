using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Necklaces
{
    public class WhiteNecklace : JewelNecklace
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Necklace");
            Tooltip.SetDefault("This necklace will let you use the power of Life and Light. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().whiteNecklace = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "WhiteStone";
            return str;
        }
    }
}
