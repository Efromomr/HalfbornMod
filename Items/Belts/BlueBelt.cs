using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Belts
{
    [AutoloadEquip(EquipType.Waist)]
    public class BlueBelt : JewelBelt
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Blue Belt");
            this.Tooltip.SetDefault("This belt will let you use the power of Water and Ice. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().blueBelt = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "BlueStone";
            return str;
        }
    }
}
