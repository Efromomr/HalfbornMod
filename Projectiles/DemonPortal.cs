using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{

    public class DemonPortal : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 52;
            projectile.height = 52;
            projectile.light = 0.3f;
            projectile.timeLeft = 120;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 4;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 127, (float)Main.rand.Next(-6, 6), (float)Main.rand.Next(-6, 6), 0, default(Color), 2f);
                Main.dust[num].noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.friendly && target.life < target.lifeMax / 2)
                target.life = 0;
        }
        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
            }
        }
    }
}
