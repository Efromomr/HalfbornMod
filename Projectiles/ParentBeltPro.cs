using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public abstract class ParentBeltPro : ModProjectile
    {
        public override void SetDefaults()
        {

            projectile.width = 36;
            projectile.height = 36;
            projectile.timeLeft = 1;
            projectile.penetrate = 1;
            projectile.friendly = true;

            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;

            projectile.aiStyle = 2;
        }


        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            projectile.light = 0f;
            projectile.alpha = 0;
        }
        public virtual string SpawnProj()
        {
            string str = "";
            return str;
        }
        public override void Kill(int timeLeft)
        {
            string proj = SpawnProj();
            Player player = Main.player[projectile.owner];
            Projectile.NewProjectile(player.Center.X - 20f, player.Center.Y - 50f, 0.0f, 0.0f, mod.ProjectileType(proj), 5, 0.0f, player.whoAmI, 0.0f, 0.0f);

        }
    }
}
