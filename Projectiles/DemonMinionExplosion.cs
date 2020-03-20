using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{

    public class DemonMinionExplosion : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 98;
            projectile.height = 98;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 15;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 7;
        }


        public override void AI()
        {
            int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, 229, 0f, 0f, 100, default(Color), 1.15f);
            Dust dust = Main.dust[num];
            dust = Main.dust[num];
            dust.velocity *= 0.2f;
            Main.dust[num].noGravity = true;
        }


        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 7)
            {
                projectile.frame = 0;
            }
        }
    }
}
