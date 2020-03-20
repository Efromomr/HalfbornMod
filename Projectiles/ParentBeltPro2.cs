using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Projectiles
{
    public abstract class ParentBeltPro2 : ModProjectile
    {
        public override void SetDefaults()
        {

            projectile.width = 36;
            projectile.height = 36;
            projectile.timeLeft = 300;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            aiType = 14;

        }


        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            projectile.light = 0.9f;
            projectile.alpha = 100;
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f);
            Main.dust[DustID].noGravity = true;
            projectile.position.X = owner.Center.X - 30f;
            projectile.position.Y = owner.Center.Y - 30f;
            return;
        }

        public virtual int BuffOnHit ()
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
            n.velocity.X +=(n.direction > 0)? + 5f : -5f;
			n.velocity.Y -=1f;
        }




    }
}
