using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{

    public class WhiteWeapon : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.tileCollide = false;
            aiType = 49;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(mod.GetTexture("Glow/WhiteWeapon_Glow"), projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(11f, 11f), 1f, SpriteEffects.None, 0f);
        }
        Player player = Main.player[Main.myPlayer];
        public override void AI()
        {
            if (player.GetModPlayer<HalfbornPlayer>().weaponOff)

                projectile.Kill();
        }
    }
}
