using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
	public class EternityScythe : ModProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_45";
			}
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eternity Scythe");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.DemonScythe);
			aiType = ProjectileID.DemonScythe;
			projectile.scale = 0.6f;
			projectile.penetrate = 1;
			projectile.minion = true;
		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Shadowflame, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 1.2f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(BuffID.Venom, 180);
			}
		}        
	}
}