using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class DemonBowSealPro : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 1;
            projectile.scale = 1f;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.timeLeft = 600;
        }

        public override void AI()
        {
            int index = Dust.NewDust(new Vector2(this.projectile.position.X + 3f, this.projectile.position.Y + 3f) - this.projectile.velocity * 0.5f, this.projectile.width - 8, this.projectile.height - 8, 60, 0.0f, 0.0f, 100, new Color(), 1.2f);
            Main.dust[index].velocity *= 0.2f;
            Main.dust[index].noGravity = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int n = target.whoAmI;
            for (int index1 = 0; index1 < 10; ++index1)
            {
                int index2 = Dust.NewDust(new Vector2(this.projectile.position.X, this.projectile.position.Y + 2f), this.projectile.width + 2, this.projectile.height + 2, 62, this.projectile.velocity.X * 0.2f, this.projectile.velocity.Y * 0.2f, 100, new Color(), 1.2f);
                Main.dust[index2].noGravity = true;

            }
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, ModContent.ProjectileType<Projectiles.DemonBowSeal>(), 1, 1f, Main.myPlayer, 1f, (float)n);
            projectile.Kill();
        }
    }
}
