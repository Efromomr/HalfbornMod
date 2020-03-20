using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Belts
{
    [AutoloadEquip(EquipType.Waist)]
    public class RedBelt : JewelBelt
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Red Belt");
            this.Tooltip.SetDefault("This belt will let you use the power of Blood and Gore. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().redBelt = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "RedStone";
            return str;
        }
    }
}
