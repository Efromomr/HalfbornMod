using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Gloves
{

    public class YellowGlove : JewelGlove
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Yellow Glove");
            this.Tooltip.SetDefault("This glove will let you use the power of Sun and Desert. ");
        }

        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().yellowGlove = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "YellowStone";
            return str;
        }


    }
}
