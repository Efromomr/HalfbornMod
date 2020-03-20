
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class BloodSeal : ModProjectile
    {
        NPC target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Seal");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public bool IsStickingToTarget
        {
            get => projectile.ai[0] == 1f;
            set => projectile.ai[0] = value ? 1f : 0f;
        }


        public int TargetWhoAmI
        {
            get => (int)projectile.ai[1];
            set => projectile.ai[1] = value;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            IsStickingToTarget = true; 
            TargetWhoAmI = target.whoAmI; 
            projectile.velocity =
                (target.Center - projectile.Center) *
                0.75f; 
            projectile.netUpdate = true; 

            projectile.damage = 0; 
            target.AddBuff(ModContent.BuffType<Buffs.CritStrike>(), 18000);
        }

       
        private const int MAX_TICKS = 45;

        public override void AI()
        {
            if (IsStickingToTarget) StickyAI();
            NormalAI();
        }

        private void NormalAI()
        {  
            for (int i = 0; i < 200; i++)
            {
                 if (Main.npc[i].life > Main.npc[i + 1].life)
                 {
                     target = Main.npc[i];
                 }
                 else
                 {
                     target = Main.npc[i + 1];
                 }
                target = Main.npc[i];

                {

                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));


                    if (distance < 480f && !target.friendly && target.active)
                    {

                        distance = 3f / distance;


                        shootToX *= distance * 5;
                        shootToY *= distance * 5;


                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }
        }

        private void StickyAI()
        {
            projectile.damage = 0;
            int projTargetIndex = (int)TargetWhoAmI;
            const int aiFactor = 90; 
            projectile.localAI[0] += 1f;

            if (projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200)
            { // If the index is past its limits, kill it
                projectile.Kill();
            }
            else if (Main.npc[projTargetIndex].active)
            {
              projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
              projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;                
            }
            else
            { 
                projectile.Kill();
            }
        }
    }
}