using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Belts
{
    [AutoloadEquip(EquipType.Waist)]
    public class GreenBelt : JewelBelt
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Green Belt");
            this.Tooltip.SetDefault("This belt will let you use the power of Life and Nature. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().greenBelt = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "GreenStone";
            return str;
        }
    }
}
