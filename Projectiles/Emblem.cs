using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;


namespace HalfbornMod.Projectiles
{
    
    public abstract class Emblem : ModProjectile
    {
        Player player = Main.player[Main.myPlayer];
        public override void SetDefaults()
        {
            projectile.width = 54;
            projectile.height = 54;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(Color.White * 0.85f * (0.1f * (float)projectile.timeLeft));
        }
        public override void AI()
        {
            projectile.position.X = player.Center.X + 20f;
            projectile.position.Y = player.Center.Y -50f;
        }
    }
}
