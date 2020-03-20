using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Gloves
{

    public class OrangeGlove : JewelGlove
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Orange Glove");
            this.Tooltip.SetDefault("This glove will let you use the power of Fire and Heat. ");
        }

        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().orangeGlove = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "OrangeStone";
            return str;
        }


    }
}
