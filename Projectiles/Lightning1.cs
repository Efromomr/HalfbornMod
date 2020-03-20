using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{

    public class Lightning1 : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.timeLeft = 60;
        }


        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            int[] array = new int[5];
            Vector2[] array2 = new Vector2[5];
            int num = 0;
            float num2 = 2000f;
            int num4;
            for (int i = 0; i < 255; i = num4 + 1)
            {
                Vector2 vector;
                vector.X = player.Center.X;
                vector.Y = player.Center.Y;
                float num3 = Vector2.Distance(vector, projectile.Center);
                if (num3 < num2)
                {
                    array[num] = i;
                    array2[num] = vector;
                    num4 = num + 1;
                    num = num4;
                    if (num4 >= array2.Length)
                    {
                        break;
                    }
                }
                num4 = i;
            }
            for (int j = 0; j < num; j = num4 + 1)
            {
                Vector2 vector2 = array2[j] - projectile.Center;
                float num5 = (float)Main.rand.Next(100);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, ModContent.ProjectileType<Projectiles.Lightning>(), projectile.damage, 0f, projectile.owner, Utils.ToRotation(vector2), num5);
                num4 = j;
                projectile.Kill();
            }
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}
