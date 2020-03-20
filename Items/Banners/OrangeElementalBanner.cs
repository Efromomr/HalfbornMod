using System;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Items.Banners
{

    public class OrangeElementalBanner : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orange Elemental Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Orange Elemental");
        }


        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("ElementalBanner");
            item.placeStyle = 5;
        }
    }
}
