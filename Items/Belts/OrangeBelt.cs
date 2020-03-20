using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Belts
{
    [AutoloadEquip(EquipType.Waist)]
    public class OrangeBelt : JewelBelt
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Orange Belt");
            this.Tooltip.SetDefault("This belt will let you use the power of Fire and Heat. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().orangeBelt = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "OrangeStone";
            return str;
        }
    }
}
