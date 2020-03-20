using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Necklaces
{
    public class YellowNecklace : JewelNecklace
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yellow Necklace");
            Tooltip.SetDefault("This necklace will let you use the power of Sun and Desert. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().yellowNecklace = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "YellowStone";
            return str;
        }
    }
}
