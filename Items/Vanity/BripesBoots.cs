﻿using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Items.Vanity
{
    [AutoloadEquip(EquipType.Legs)]
    public class BripesBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bripe's Boots");
            Tooltip.SetDefault("Great for impersonating devs!");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 9;
            item.vanity = true;
        }
    }
}