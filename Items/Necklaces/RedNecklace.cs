using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Necklaces
{
    public class RedNecklace : JewelNecklace
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Necklace");
            Tooltip.SetDefault("This necklace will let you use the power of Fire and Heat. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().redNecklace = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "RedStone";
            return str;
        }
    }
}
