using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Items.Vanity
{
    [AutoloadEquip(EquipType.Legs)]
    public class MeuRansGreaves : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("MeuRan's Greaves");
            Tooltip.SetDefault("Great for impersonating devs!");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 9;
            item.vanity = true;
        }
    }
}