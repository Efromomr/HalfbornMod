using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Gloves
{

    public class BlueGlove : JewelGlove
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Blue Glove");
            this.Tooltip.SetDefault("This glove will let you use the power of Ice and Water. ");
        }

        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().blueGlove = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "BlueStone";
            return str;
        }


    }
}
