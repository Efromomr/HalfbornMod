using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Necklaces
{
    public class BlackNecklace : JewelNecklace
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Necklace");
            Tooltip.SetDefault("This necklace will let you use the power of Death and Darkness. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().blackNecklace = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "BlackStone";
            return str;
        }
    }
}
