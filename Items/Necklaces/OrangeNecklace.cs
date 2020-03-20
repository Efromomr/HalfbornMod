using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Necklaces
{
    public class OrangeNecklace : JewelNecklace
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orange Necklace");
            Tooltip.SetDefault("This necklace will let you use the power of Fire and Heat. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().orangeNecklace = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "OrangeStone";
            return str;
        }
    }
}
