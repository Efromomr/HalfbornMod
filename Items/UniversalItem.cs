using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace HalfbornMod.Items
{
    public class UniversalItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Universal Item");
            Tooltip.SetDefault("This item can do practically everything. Except for helping you to do your homework.");
        }

        public override void SetDefaults()
        {
            item.damage = 3;
            item.noMelee = true;
            item.magic = true;
            item.mana = 5;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.knockBack = 1;
            item.value = 0;
            item.rare = 1;
            item.UseSound = SoundID.Item7;
            item.autoReuse = true;
            item.shoot = 90; 
            item.shootSpeed = 10f;
            Item.staff[item.type] = true;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.GetModPlayer<HalfbornPlayer>().orangeGlove)
            {
                for (int index = 0; index < 2; ++index)
                    Projectile.NewProjectile(player.Center.X-10, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType<Projectiles.OrangeWeapon>(), damage, knockBack, player.whoAmI, (float)index, 0.0f);
                
            }
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<HalfbornPlayer>().anyRing)
            {
                item.damage = 15;
                item.useTime = 12;
                item.useAnimation = 12;
                item.shootSpeed = 10;
                item.useStyle = 5;
                Item.staff[item.type] = true;
            }
            if (player.GetModPlayer<HalfbornPlayer>().blackRing)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.BlackRingPro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().blueRing)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.BlueRingPro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().greenRing)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.GreenRingPro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().orangeRing)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.OrangeRingPro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().yellowRing)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.YellowRingPro>(); 
            }
            if (player.GetModPlayer<HalfbornPlayer>().redRing)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.RedRingPro>(); 
            }
            if (player.GetModPlayer<HalfbornPlayer>().whiteRing)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.WhiteRingPro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().anyBelt)
            {
                item.damage = 10;
                item.useTime = 20;
                item.useAnimation = 20;
                item.shootSpeed = 5;
                item.useStyle = 5;
                Item.staff[item.type] = true;
            }
            if (player.GetModPlayer<HalfbornPlayer>().blackBelt)
            {
                 item.shoot = ModContent.ProjectileType<Projectiles.BlackBeltPro>();
            }
             if (player.GetModPlayer<HalfbornPlayer>().blueBelt)
             {
                 item.shoot = ModContent.ProjectileType<Projectiles.BlueBeltPro>();
            }
             if (player.GetModPlayer<HalfbornPlayer>().greenBelt)
             {
                 item.shoot = ModContent.ProjectileType<Projectiles.GreenBeltPro>();
            }
             if (player.GetModPlayer<HalfbornPlayer>().orangeBelt)
             {
                 item.shoot = ModContent.ProjectileType<Projectiles.OrangeBeltPro>();
            }
             if (player.GetModPlayer<HalfbornPlayer>().yellowBelt)
             {
                 item.shoot = ModContent.ProjectileType<Projectiles.YellowBeltPro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().redBelt)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.RedBeltPro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().whiteBelt)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.WhiteBeltPro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().anyNecklace)
            {
                item.damage = 10;
                item.mana = 10;
                item.useTime = 20;
                item.useAnimation = 20;
                item.shootSpeed = 3;
                item.useStyle = 5;
                Item.staff[item.type] = true;
            }
            if (player.GetModPlayer<HalfbornPlayer>().blackNecklace)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.BlackNecklacePro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().blueNecklace)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.BlueNecklacePro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().greenNecklace)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.GreenNecklacePro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().orangeNecklace)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.OrangeNecklacePro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().yellowNecklace)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.YellowNecklacePro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().redNecklace)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.RedNecklacePro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().whiteNecklace)
            {
                item.shoot = ModContent.ProjectileType<Projectiles.WhiteNecklacePro>();
            }
            if (player.GetModPlayer<HalfbornPlayer>().anyGlove && player.FindBuffIndex(ModContent.BuffType<Buffs.MagicWeapon>()) < 0 && player.FindBuffIndex(ModContent.BuffType<Buffs.Overheat>()) < 0)
            {
                player.AddBuff(ModContent.BuffType<Buffs.MagicWeapon>(), 600);
                item.useStyle = 1;
                Item.staff[item.type] = false;
            }
            if (player.GetModPlayer<HalfbornPlayer>().yellowGlove&& !player.GetModPlayer<HalfbornPlayer>().weaponOff)
            {
                item.damage = 15;
                item.noMelee = false;
                item.melee = true;
                item.useStyle = 1;
                item.mana = 0;
                item.noUseGraphic = true;
                item.shoot = 0;
            }
            if (player.GetModPlayer<HalfbornPlayer>().redGlove && !player.GetModPlayer<HalfbornPlayer>().weaponOff)
            {
                item.damage = 15;
                item.noMelee = false;
                item.melee = true;
                item.useStyle = 1;
                item.mana = 0;
                item.noUseGraphic = true;
                item.shoot = 0;
            }
            if (player.GetModPlayer<HalfbornPlayer>().whiteGlove && !player.GetModPlayer<HalfbornPlayer>().weaponOff)
            {
            item.damage = 20;
            item.autoReuse = false;
            item.useStyle = 5;
            item.useAnimation = 18;
            item.useTime = 24;
            item.shootSpeed = 4;
            item.knockBack = 7f;
            item.melee = true;
            item.noMelee = true; 
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<Projectiles.WhiteWeapon>();             
            }
            if (player.GetModPlayer<HalfbornPlayer>().greenGlove && !player.GetModPlayer<HalfbornPlayer>().weaponOff)
            {
                item.damage = 15;
                item.noMelee = false;
                item.melee = true;
                item.useStyle = 1;
                item.mana = 0;
                item.noUseGraphic = true;
                item.shoot = 0;
            }
            if (player.GetModPlayer<HalfbornPlayer>().blackGlove && !player.GetModPlayer<HalfbornPlayer>().weaponOff)
            {
                item.damage = 15;
                item.noMelee = false;
                item.melee = true;
                item.useStyle = 1;
                item.mana = 0;
                item.noUseGraphic = true;
                item.shoot = 0;
            }
            if (player.GetModPlayer<HalfbornPlayer>().orangeGlove && !player.GetModPlayer<HalfbornPlayer>().weaponOff)
            {
                item.damage = 25;               
                item.useTime = 22;
                item.useAnimation = 22;
                item.useStyle = 1;
                item.noMelee = true;
                item.noUseGraphic = true;
                item.autoReuse = true;
                item.knockBack = 6.5f;
                item.UseSound = SoundID.Item1;
                item.shoot = ModContent.ProjectileType<Projectiles.OrangeWeapon>();
                item.shootSpeed = 0.1f;
            }
            if (player.GetModPlayer<HalfbornPlayer>().blueGlove && !player.GetModPlayer<HalfbornPlayer>().weaponOff)
            {

                item.damage = 15;
                item.noMelee = true;
                item.useStyle = 5;
                item.useAnimation = 20;
                item.useTime = 20;
                item.autoReuse = true;
                item.knockBack = 7f;
                item.noUseGraphic = true;
                item.shoot = ModContent.ProjectileType<Projectiles.BlueWeapon>();
                item.shootSpeed = 18f;
                item.UseSound = SoundID.Item1;
                item.melee = true;
                item.channel = true;
                for (int i = 0; i < 1000; i++)
                {
                    if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.BlueWeapon>()] < 1)
                    {
                        return true;
                    }
                }
            }

            if (!player.GetModPlayer<HalfbornPlayer>().jewelAcc||player.GetModPlayer<HalfbornPlayer>().weaponOff)
            {
                item.damage = 3;
                item.noMelee = true;
                item.magic = true;
                item.mana = 5;
                item.width = 40;
                item.height = 40;
                item.useTime = 20;
                item.useAnimation = 20;
                item.useStyle = 5;
                item.knockBack = 1;
                item.value = 0;
                item.rare = 1;
                item.UseSound = SoundID.Item7;
                item.autoReuse = true;
                item.shoot = 90; 
                item.shootSpeed = 10f;
                item.noUseGraphic = false;
                Item.staff[item.type] = true;
            }
            return true;
        }
    }
}
