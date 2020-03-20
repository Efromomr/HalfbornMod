using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
	
	public class DemonMinion : HiredShooter
	{
		
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 2;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 58;
			projectile.height = 56;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			inertia = 25f;
	    	shoot = ModContent.ProjectileType<EternityScythe>();
			shootSpeed = 10f;
		}

		public override void CheckActive()
		{
			if (!Main.LocalPlayer.HasBuff(ModContent.BuffType<Buffs.DemonMinionBuff>()))
				projectile.Kill();
		}

		public override void SelectFrame()
		{
			++projectile.frameCounter;
			if (projectile.frameCounter > 2)
			{
				++projectile.frame;
				projectile.frameCounter = 0;
			}
			if (projectile.frame < 2)
				return;
			projectile.frame = 0;
		}
	}
}
