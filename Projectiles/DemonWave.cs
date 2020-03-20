using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace HalfbornMod.Projectiles
{

    public class DemonWave : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wave");
        }


        public override void AI()
		{
			Player player = Main.player[this.projectile.owner];
			int d = 6;
                    if (player.GetModPlayer<HalfbornPlayer>().warDemon) d = 6;
                    if (player.GetModPlayer<HalfbornPlayer>().shootDemon) d = 18;
                    if (player.GetModPlayer<HalfbornPlayer>().mageDemon) d = 70;
                    if (player.GetModPlayer<HalfbornPlayer>().summonDemon) d = 67;
                    for (int i = 0; i < 35; i++)                  
				{
					
                    int dust = Dust.NewDust(player.position, player.width, player.height, d, 0f, -2f, 0, default(Color), 2f);
                    Main.dust[dust].noGravity = true;
                    Dust dust2 = Main.dust[dust];
                    dust2.position.X = dust2.position.X + ((Main.rand.Next(-50, 51) / 20) - 1.5f);
                    Dust dust3 = Main.dust[dust];
                    dust3.position.Y = dust3.position.Y + ((Main.rand.Next(-50, 51) / 20) - 1.5f);
                    if (Main.dust[dust].position != player.Center)
                    {
                      Main.dust[dust].velocity = player.DirectionTo(Main.dust[dust].position) * 7f;
                    }
                }           
		}
		
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 3;
        }
    }
}
