using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Rings
{
    [AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
    public class BlackRing : JewelRing
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Ring");
            Tooltip.SetDefault("This ring will let you use the power of Death and Darkness. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().blackRing = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "BlackStone";
            return str;
        }
    }
}
