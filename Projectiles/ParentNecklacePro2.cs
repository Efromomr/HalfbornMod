using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public abstract class ParentNecklacePro2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;

            projectile.light = 0.9f;
            projectile.penetrate = -1;
            projectile.timeLeft = 240;

            projectile.friendly = true;
            projectile.tileCollide = true;

            aiType = 24;

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


    }
}
