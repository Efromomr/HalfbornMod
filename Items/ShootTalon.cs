using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HalfbornMod.Items
{

    public class ShootTalon : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ranger's Talon");
            Tooltip.SetDefault("Awake a monster inside...");
        }

        Player player = Main.player[Main.myPlayer];
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item119;
            item.consumable = true;
        }
        public override bool UseItem(Player player)
        {
            player.GetModPlayer<HalfbornPlayer>().shootDemon = true;
            
            if (player.GetModPlayer<HalfbornPlayer>().demonPower == 0)
            {
                player.GetModPlayer<HalfbornPlayer>().demonPower = 1;
            }
            player.GetModPlayer<HalfbornPlayer>().mageDemon = false;
            player.GetModPlayer<HalfbornPlayer>().warDemon = false;
            player.GetModPlayer<HalfbornPlayer>().summonDemon = false;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(null, "EmptyTalon", 1);
            modRecipe.AddTile(26);
            modRecipe.SetResult(this);
            modRecipe.AddRecipe();
        }
    }
}
