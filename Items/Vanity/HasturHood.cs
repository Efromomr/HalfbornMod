using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class HasturHood : ModItem
    {
      
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hastur's Hood");
            Tooltip.SetDefault("Great for impersonating devs!");
        }

        public override void SetDefaults()
        {           
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 7, 0, 0);
            item.rare = 9;
            item.vanity = true;
        }
    }
}