using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Items
{
    public class EmptyTalon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Empty Talon");
            Tooltip.SetDefault("Use it on the Demon Altar.");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
        }    	
    }
}
