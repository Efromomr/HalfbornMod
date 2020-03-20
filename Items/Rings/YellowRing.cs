using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Rings
{
    [AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
    public class YellowRing : JewelRing
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yellow Ring");
            Tooltip.SetDefault("This ring will let you use the power of Sun and Desert. ");
        }
        public override void SafeUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<HalfbornPlayer>().yellowRing = true;
        }
        public override string SafeAddRecipes()
        {
            string str = "YellowStone";
            return str;
        }
    }
}


