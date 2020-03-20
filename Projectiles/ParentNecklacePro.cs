using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public abstract class ParentNecklacePro : ModProjectile
    {
            public override void SetDefaults()
            {

                projectile.width = 36;
                projectile.height = 36;
                projectile.timeLeft = 120;
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
                projectile.light = 0.9f;
                projectile.alpha = 0;

                int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f);
                Main.dust[DustID].noGravity = true;

            }

        public virtual int BuffOnHit()
        {
            int num = 0;
            return num;
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
            {
            int buffID = BuffOnHit();
                Player owner = Main.player[projectile.owner];
                int rand = Main.rand.Next(2);
                if (rand == 0)
                {
                    n.AddBuff(buffID, 180);
                }

            }

            public virtual string SpawnProj()
            {
                string str = "";
                return str;
            }
            public override bool OnTileCollide(Vector2 oldVelocity)
            {
                string proj = SpawnProj();
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 40f, 0, 0, mod.ProjectileType("proj"), (int)(projectile.damage * 1.5), projectile.knockBack, Main.myPlayer);
                projectile.Kill();
                return false;
            }
        }
    }

