using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Items.Stones
{

    public class WhiteShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Shard");
            Tooltip.SetDefault("Oops! It's really hot. ");
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
            item.placeStyle = 6;
        }
    }
}