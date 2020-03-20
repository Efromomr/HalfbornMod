using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Items.DemonItems
{

    public class DemonAxe : ModItem
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Axe");
            Tooltip.SetDefault("Right click while being in war demon form to shoot a boomerang-like axe");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 6f;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 3;
            item.shoot = ModContent.ProjectileType<Projectiles.DemonAxePro>();
            item.shootSpeed = 16f;
        }

        public override bool AltFunctionUse(Player player)
        {
            if (player.GetModPlayer<HalfbornPlayer>().demonForm && player.GetModPlayer<HalfbornPlayer>().warDemon) return true;
            return false;
        }


        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.noMelee = true;
                item.noUseGraphic = true;
                item.autoReuse = false;
            }
            else
            {                   
                item.noMelee = false;
                item.noUseGraphic = false;
                item.autoReuse = false;
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.GetModPlayer<HalfbornPlayer>().warDemon && player.GetModPlayer<HalfbornPlayer>().demonForm && player.altFunctionUse == 2)
            {
                for (int index = 0; index < 1; ++index)
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Projectiles.DemonAxePro>(), damage, knockBack, player.whoAmI, 0.0f, 0.0f);
                }
            }
            return false;
        }

    }
}
