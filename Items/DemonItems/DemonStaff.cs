using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HalfbornMod.Items.DemonItems
{

    public class DemonStaff : ModItem
    {
        Player player = Main.player[Main.myPlayer];
        string proj = "DemonStaffPro";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Staff");
            Tooltip.SetDefault("Right click while being in mage demon form to shoot a cursed seal.");
        }


        public override void SetDefaults()
        {
            item.mana = 15;
            item.width = 30;
            item.height = 30;
            item.useTime = 42;
            item.useAnimation = 42;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 0f;
            item.value = 37500;
            item.rare = 3;
            item.UseSound = SoundID.Item34;
            item.shoot = ModContent.ProjectileType<Projectiles.DemonStaffPro>();
            item.shootSpeed = 32f;
        }

        public override bool AltFunctionUse(Player player)
        {
            if (player.GetModPlayer<HalfbornPlayer>().demonForm && player.GetModPlayer<HalfbornPlayer>().mageDemon) return true;
            return false;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (Main.projectile[j].active && Main.projectile[j].type == ModContent.ProjectileType<Projectiles.DemonStaffSeal>() && Main.projectile[j].owner == player.whoAmI)
                {
                    Projectile seal = Main.projectile[j];
                    Projectile.NewProjectile(seal.position.X, seal.position.Y, 0f, 0f, ModContent.ProjectileType<Projectiles.DemonStaffExplosion>(), 5, 5f, player.whoAmI);
                }
            }
                if (player.GetModPlayer<HalfbornPlayer>().mageDemon && player.GetModPlayer<HalfbornPlayer>().demonForm && player.altFunctionUse == 2)
                    proj = "DemonStaffSealPro";
                else proj = "DemonStaffPro";

                float num1 = 0.783f;
                double num2 = Math.Atan2((double)speedX, (double)speedY) - (double)num1 / 2.0;
                double num3 = (double)num1 / 8.0;
                for (int index = 0; index < 1; ++index)
                {
                    double num4 = num3 * (double)(index + index * index) / 2.0;
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType(proj), 5, 5f, player.whoAmI, 0.0f, 0.0f);
                }
                return false;          
        }
    }
}
