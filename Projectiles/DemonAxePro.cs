using System;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{

    public class DemonAxePro : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 32;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            aiType = 52;
        }
    }
}