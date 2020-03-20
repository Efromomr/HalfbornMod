using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Rings
{
    [AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
    public class GreenRing : JewelRing
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Ring");
            Tooltip.SetDefault("This ring will let you use the power of Life and Nature. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().greenRing = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "GreenStone";
            return str;
        }
    }
}
