
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class DemonBowSeal : ModProjectile
    {
        NPC target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Seal");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 3;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            return projHitbox.Intersects(targetHitbox);
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

        private readonly Point[] stickingSeals = new Point[1];

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            IsStickingToTarget = true;
            TargetWhoAmI = target.whoAmI;
            target.velocity =
                (target.Center - projectile.Center) *
                0.75f;
            projectile.netUpdate = true;

            projectile.damage = 0;

            UpdateStickyJavelins(target);
        }

        private void UpdateStickyJavelins(NPC target)
        {
            int currentSealIndex = 0;

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile currentProjectile = Main.projectile[i];
                if (i != projectile.whoAmI
                    && currentProjectile.active
                    && currentProjectile.owner == Main.myPlayer
                    && currentProjectile.type == projectile.type
                    && currentProjectile.modProjectile is DemonBowSeal sealProjectile
                    && sealProjectile.IsStickingToTarget
                    && sealProjectile.TargetWhoAmI == target.whoAmI)
                {

                    stickingSeals[currentSealIndex++] = new Point(i, currentProjectile.timeLeft);
                    if (currentSealIndex >= stickingSeals.Length)
                        break;
                }
            }

            if (currentSealIndex >= 1)
            {
                int oldIndex = 0;

                for (int i = 1; i < 1; i++)
                {

                    if (stickingSeals[i].Y < stickingSeals[oldIndex].Y)
                    {
                        oldIndex = i; 
                    }
                }

                Main.projectile[stickingSeals[oldIndex].X].Kill();
            }
        }



        private const int ALPHA_REDUCTION = 25;

        public override void AI()
        {
            int projTargetIndex = (int)TargetWhoAmI;
            const int aiFactor = 15;
            projectile.localAI[0] += 1f;

            if (projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200)
            {
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