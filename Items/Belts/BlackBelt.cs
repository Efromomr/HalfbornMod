using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Belts
{
    [AutoloadEquip(EquipType.Waist)]
    public class BlackBelt : JewelBelt
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Black Belt");
            this.Tooltip.SetDefault("This belt will let you use the power of Death and Darkness. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().blackBelt = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "BlackStone";
            return str;
        }
    }
}
