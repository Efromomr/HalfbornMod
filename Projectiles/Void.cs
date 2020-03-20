using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{

    public class Void : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 42;
            projectile.aiStyle = -1;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 90;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 150, default(Color), 1.25f);
                Main.dust[num].noGravity = true;
            }
            if (projectile.velocity.X > 1f)
            {
                projectile.spriteDirection = -1;
                projectile.rotation -= 0.15f;
            }
            else
            {
                projectile.spriteDirection = 1;
                projectile.rotation += 0.15f;
            }
            for (int i = 0; i < 200; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && (npc.type < 552 || npc.type > 578) && npc.type != 488 && !npc.friendly && !npc.boss && npc.CanBeChasedBy(projectile, false) && Vector2.Distance(projectile.Center, npc.Center) < 100f)
                {
                    float num2 = 8f;
                    Vector2 vector = new Vector2(npc.position.X + (float)(npc.width / 2), npc.position.Y + (float)(npc.height / 2));
                    float num3 = projectile.Center.X - vector.X;
                    float num4 = projectile.Center.Y - vector.Y;
                    float num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
                    num5 = num2 / num5;
                    num3 *= num5;
                    num4 *= num5;
                    int num6 = 1;
                    npc.velocity.X = (npc.velocity.X * (float)(num6) + num3) / (float)num6;
                    npc.velocity.Y = (npc.velocity.Y * (float)(num6) + num4) / (float)num6;
                }
            }
        }
    }
}
