using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Necklaces
{
    public class BlueNecklace : JewelNecklace
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Necklace");
            Tooltip.SetDefault("This necklace will let you use the power of Water and Ice. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().blueNecklace = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "BlueStone";
            return str;
        }
    }
}
