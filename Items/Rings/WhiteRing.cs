using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Rings
{
    [AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
    public class WhiteRing : JewelRing
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Ring");
            Tooltip.SetDefault("This ring will let you use the power of Life and Light. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().whiteRing = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "WhiteStone";
            return str;
        }
    }
}
