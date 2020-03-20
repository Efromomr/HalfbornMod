using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Rings
{
    [AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
    public class BlueRing : JewelRing
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Ring");
            Tooltip.SetDefault("This ring will let you use the power of Water and Ice. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().blueRing = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "BlueStone";
            return str;
        }
    }
}
