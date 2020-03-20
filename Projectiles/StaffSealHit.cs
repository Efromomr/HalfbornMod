using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class StaffSealHit : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 52;
            projectile.height = 52;
            projectile.aiStyle = 0;
            projectile.magic = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 21;
            projectile.tileCollide = false;
            aiType = 14;
        }
    }
}