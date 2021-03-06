﻿using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Items.Vanity
{
    [AutoloadEquip(new EquipType[] { EquipType.Head })]
    public class EfromomrsHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Efromomr's Hood");
            Tooltip.SetDefault("'Great for impersonating Halfborn Devs!'");
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
