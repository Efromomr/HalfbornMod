using System;
using Terraria;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace HalfbornMod.Items.DemonItems
{

    public class DemonBow : ModItem
    {
        Player player = Main.player[Main.myPlayer];
        string proj = "Arrow";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Bow");
            Tooltip.SetDefault("Right click while being in ranger demon form to shoot a cursed seal.");
        }


        public override void SetDefaults()
        {
            item.damage = 26;
            item.crit = 11;
            item.ranged = true;
            item.width = 42;
            item.height = 30;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 6f;
            item.value = Item.sellPrice(0, 0, 34, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.shoot = 1;
            item.shootSpeed = 14f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool AltFunctionUse(Player player)
        {
            if (player.GetModPlayer<HalfbornPlayer>().demonForm && player.GetModPlayer<HalfbornPlayer>().shootDemon) return true;
            return false;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (Main.projectile[j].active && Main.projectile[j].type == ModContent.ProjectileType<Projectiles.DemonBowSeal>() && Main.projectile[j].owner == player.whoAmI)
                {
                    Projectile seal = Main.projectile[j];
                    Projectile.NewProjectile(seal.position.X, seal.position.Y, 0f, 0f, ModContent.ProjectileType<Projectiles.DemonStaffExplosion>(), 5, 5f, player.whoAmI);
                }
            }
            if (player.GetModPlayer<HalfbornPlayer>().shootDemon && player.GetModPlayer<HalfbornPlayer>().demonForm && player.altFunctionUse == 2)
			{

            float num1 = 0.783f;
            double num2 = Math.Atan2((double)speedX, (double)speedY) - (double)num1 / 2.0;
            double num3 = (double)num1 / 8.0;
            for (int index = 0; index < 1; ++index)
            {
                double num4 = num3 * (double)(index + index * index) / 2.0;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("DemonBowSealPro"), 5, 5f, player.whoAmI, 0.0f, 0.0f);
            }
			}
			else 
			{
			float num1 = 0.783f;
            double num2 = Math.Atan2((double)speedX, (double)speedY) - (double)num1 / 2.0;
            double num3 = (double)num1 / 8.0;
            for (int index = 0; index < 1; ++index)
            {
                double num4 = num3 * (double)(index + index * index) / 2.0;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 5, 5, 5f, player.whoAmI, 0.0f, 0.0f);
            }
			}
            return false;
        }
    }
}
