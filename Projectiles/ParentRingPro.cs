using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Projectiles
{
    public abstract class ParentRingPro : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.timeLeft = 60;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.aiStyle = 1;
            Main.projFrames[this.projectile.type] = 5;
        }


        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            projectile.light = 0.9f;
            projectile.alpha = 0;
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f);
            Main.dust[DustID].noGravity = true;
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                {

                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));


                    if (distance < 480f && !target.friendly && target.active)
                    {

                        distance = 3f / distance;


                        shootToX *= distance * 5;
                        shootToY *= distance * 5;


                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }

        }

        public virtual int BuffOnHit()
        {
            int num = 0;
            return num;
        }
        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            int buffID = BuffOnHit();
            Player owner = Main.player[projectile.owner];
            int rand = Main.rand.Next(2);
            if (rand == 0)
            {
                n.AddBuff(buffID, 180);
            }

        }

        public override void PostAI()
        {
            ++this.projectile.frameCounter;
            if (this.projectile.frameCounter > 5)
            {
                ++this.projectile.frame;
                this.projectile.frameCounter = 0;
            }
            if (this.projectile.frame < 5)
                return;
            this.projectile.frame = 0;
        }




    }
}
