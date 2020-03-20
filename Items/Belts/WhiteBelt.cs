using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Belts
{
    [AutoloadEquip(EquipType.Waist)]
    public class WhiteBelt : JewelBelt
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("White Belt");
            this.Tooltip.SetDefault("This belt will let you use the power of Life and Light. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().whiteBelt = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "WhiteStone";
            return str;
        }
    }
}
