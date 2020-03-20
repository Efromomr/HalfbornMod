using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Gloves
{

    public class RedGlove : JewelGlove
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Red Glove");
            this.Tooltip.SetDefault("This glove will let you use the power of Blood and Gore. ");
        }

        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().redGlove = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "RedStone";
            return str;
        }


    }
}
