using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Rings
{
    [AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
    public class OrangeRing : JewelRing
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orange Ring");
            Tooltip.SetDefault("This ring will let you use the power of Fire and Heat. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().orangeRing = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "OrangeStone";
            return str;
        }
    }
}
