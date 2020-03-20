using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class OrangeWeapon : ModProjectile
    {
        

        public override void SetDefaults()
        {
            
            projectile.width = 174;
            projectile.height = 174;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.light = 0.2f;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ownerHitCheck = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 26;
        }

      

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[this.projectile.owner];
            if ((double)target.Center.X < (double)player.Center.X)
                hitDirection = -1;
            else
                hitDirection = 1;
        }

        public override void AI()
        {
            Player player = Main.player[this.projectile.owner];
            if (player.dead || player.GetModPlayer<HalfbornPlayer>().weaponOff)
                this.projectile.Kill();
            if (player.direction > 0)
            {
                this.projectile.rotation += 0.25f;
                this.projectile.spriteDirection = 1;
            }
            else
            {
                this.projectile.rotation -= 0.25f;
                this.projectile.spriteDirection = -1;
            }
            this.projectile.position.X = player.Center.X-87;
            this.projectile.position.Y = player.Center.Y-87;
            projectile.alpha = 0;
            if (this.projectile.timeLeft < 8)
                this.projectile.alpha = 100;
            if (this.projectile.timeLeft < 6)
                this.projectile.alpha = 140;
            if (this.projectile.timeLeft < 4)
                this.projectile.alpha = 180;
            if (this.projectile.timeLeft >= 2)
                return;
            this.projectile.alpha = 220;
        }
    }
}
