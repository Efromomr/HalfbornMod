using System;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
	
	public abstract class Minion : ModProjectile
	{
		
		public override void AI()
		{
			this.CheckActive();
			this.Behavior();
		}

		
		public abstract void CheckActive();

		
		public abstract void Behavior();
	}
}
