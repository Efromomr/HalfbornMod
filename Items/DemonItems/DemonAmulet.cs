using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Items.DemonItems
{

    public class DemonAmulet: ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Amulet");
            Tooltip.SetDefault("Summons a demon minion which guards you. \nSummons twice more demons when in summon demon form");
        }


        public override void SetDefaults()
        {
            item.damage = 30;
            item.summon = true;
            item.mana = 10;
            item.width = 26;
            item.height = 28;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 4;
            item.noMelee = true;
            item.knockBack = 5f;
            item.value = 125000;
            item.rare = 4;
            item.shoot = ModContent.ProjectileType<Projectiles.DemonMinion>();
            item.shootSpeed = 10f;
        }


        public override bool AltFunctionUse(Player player)
        {
            return true;
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.GetModPlayer<HalfbornPlayer>().demonForm && player.GetModPlayer<HalfbornPlayer>().summonDemon)
            {
               for (int i = 0; i < 2; i++)
               {
                    Projectile.NewProjectile(player.position.X, player.position.Y, 0f, -1f, ModContent.ProjectileType<Projectiles.DemonMinion>(), 20, 5f, player.whoAmI, 0f, 0f);
               }
            }
            player.AddBuff(ModContent.BuffType<Buffs.DemonMinionBuff>(), 3600, true);
            return player.altFunctionUse != 2;
        }


        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return UseItem(player);
        }
    }
}
