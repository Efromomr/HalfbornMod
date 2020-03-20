using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Belts
{
    [AutoloadEquip(EquipType.Waist)]
    public class YellowBelt : JewelBelt
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Yellow Belt");
            this.Tooltip.SetDefault("This belt will let you use the power of Sun and Desert. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().yellowBelt = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "YellowStone";
            return str;
        }
    }
}
