﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Stones
{

    public class YellowShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Yellow Shard");
            this.Tooltip.SetDefault("This stone is as hard as glass. ");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 999;
            item.value = 6000;
            item.rare = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("CrystalTiles");
            item.placeStyle = 3;
        }

    }
}
