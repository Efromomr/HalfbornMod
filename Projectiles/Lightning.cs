using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace HalfbornMod.Projectiles
{

    public class Lightning : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 7;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 90;
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                if (projectile.oldPos[i] == Vector2.Zero)
                {
                    return false;
                }
                Vector2 position = projectile.oldPos[i] - Main.screenPosition + projectile.Size / 2f;
                spriteBatch.Draw(mod.GetTexture("Projectiles/Lightning_Glow"), position, null, Color.White, 0f, projectile.Size / 2f, 0.65f, SpriteEffects.None, 0f);
            }
            return true;
        }


        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            for (int i = 0; i < projectile.oldPos.Length; i++)
            {
                if (projectile.oldPos[i] == Vector2.Zero)
                {
                    return;
                }
                Vector2 position = projectile.oldPos[i] - Main.screenPosition + projectile.Size / 2f;
                spriteBatch.Draw(Main.projectileTexture[projectile.type], position, null, Color.White, 0f, projectile.Size / 2f, 0.5f, SpriteEffects.None, 0f);
            }
        }


        public override void OnHitNPC(NPC npc, int damage, float knockback, bool crit)
        {
            npc.immune[projectile.owner] = 5;
        }


        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage += target.defense / 2;
        }


        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (Vector2.Distance(player.Center, projectile.Center) > 1000f)
            {
                projectile.Kill();
            }
            if (projectile.velocity == Vector2.Zero)
            {
                float num = projectile.rotation + 1.57079637f + ((Main.rand.Next(2) == 1) ? -1f : 1f) * 1.57079637f;
                float num2 = (float)Main.rand.NextDouble() * 1.25f + 1.25f;
                Vector2 vector = new Vector2((float)Math.Cos((double)num) * num2, (float)Math.Sin((double)num) * num2);
                int num3 = Dust.NewDust(projectile.oldPos[projectile.oldPos.Length - 1], 0, 0, 107, vector.X, vector.Y, 0, default(Color), 1f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].scale = 1f;
            }
            if (projectile.timeLeft < 598)
            {
                if (projectile.localAI[1] == 0f && projectile.ai[0] >= 900f)
                {
                    projectile.ai[0] -= 1000f;
                    projectile.localAI[1] = -1f;
                }
                int num4 = projectile.frameCounter;
                projectile.frameCounter = num4 + 1;
                Lighting.AddLight(projectile.Center, 0.1f, 0.45f, 0.5f);
                if (projectile.velocity == Vector2.Zero)
                {
                    if (projectile.frameCounter >= projectile.extraUpdates * 2)
                    {
                        projectile.frameCounter = 0;
                        bool flag = true;
                        for (int i = 1; i < projectile.oldPos.Length; i = num4 + 1)
                        {
                            if (projectile.oldPos[i] != projectile.oldPos[0])
                            {
                                flag = false;
                            }
                            num4 = i;
                        }
                        if (flag)
                        {
                            projectile.Kill();
                        }
                    }
                    if (Main.rand.Next(projectile.extraUpdates) == 0 && (projectile.velocity != Vector2.Zero || Main.rand.Next((projectile.localAI[1] == 2f) ? 2 : 6) == 0))
                    {
                        for (int j = 0; j < 2; j = num4 + 1)
                        {
                            float num5 = projectile.rotation + ((Main.rand.Next(2) == 1) ? -1f : 1f) * 1.57079637f;
                            float num6 = (float)Main.rand.NextDouble() * 0.8f + 1f;
                            Vector2 vector2 = new Vector2((float)Math.Cos((double)num5) * num6, (float)Math.Sin((double)num5) * num6);
                            int num7 = Dust.NewDust(projectile.Center, 0, 0, 107, vector2.X, vector2.Y, 0, default(Color), 1f);
                            Main.dust[num7].noGravity = true;
                            Main.dust[num7].scale = 1.2f;
                            num4 = j;
                        }
                        if (Main.rand.Next(5) == 0)
                        {
                            Vector2 value = Utils.RotatedBy(projectile.velocity, 1.5707963705062866, default(Vector2)) * ((float)Main.rand.NextDouble() - 0.5f) * (float)projectile.width;
                            int num8 = Dust.NewDust(projectile.Center + value - Vector2.One * 4f, 8, 8, 107, 0f, 0f, 100, default(Color), 1.5f);
                            Dust dust = Main.dust[num8];
                            dust.velocity *= 0.5f;
                            Main.dust[num8].velocity.Y = -Math.Abs(Main.dust[num8].velocity.Y);
                            return;
                        }
                    }
                }
                else if (projectile.frameCounter >= projectile.extraUpdates * 2)
                {
                    projectile.frameCounter = 0;
                    float num9 = projectile.velocity.Length();
                    UnifiedRandom unifiedRandom = new UnifiedRandom((int)projectile.ai[1]);
                    int num10 = 0;
                    Vector2 vector3 = -Vector2.UnitY;
                    Vector2 vector4;
                    do
                    {
                        int num11 = unifiedRandom.Next();
                        projectile.ai[1] = (float)num11;
                        num11 %= 100;
                        float num12 = (float)num11 / 100f * 6.28318548f;
                        vector4 = Utils.ToRotationVector2(num12);
                        if (vector4.Y > 0f)
                        {
                            vector4.Y *= -1f;
                        }
                        bool flag2 = false;
                        if (vector4.Y > -0.02f)
                        {
                            flag2 = true;
                        }
                        if (vector4.X * (float)(projectile.extraUpdates + 1) * 2f * num9 + projectile.localAI[0] > 35f)
                        {
                            flag2 = true;
                        }
                        if (vector4.X * (float)(projectile.extraUpdates + 1) * 2f * num9 + projectile.localAI[0] < -35f)
                        {
                            flag2 = true;
                        }
                        if (!flag2)
                        {
                            goto IL_637;
                        }
                        num4 = num10;
                        num10 = num4 + 1;
                    }
                    while (num4 < 100);
                    projectile.velocity = Vector2.Zero;
                    if (projectile.localAI[1] < 1f)
                    {
                        projectile.localAI[1] += 2f;
                        goto IL_63B;
                    }
                    goto IL_63B;
                    IL_637:
                    vector3 = vector4;
                    IL_63B:
                    if (projectile.velocity != Vector2.Zero)
                    {
                        projectile.localAI[0] += vector3.X * (float)(projectile.extraUpdates + 1) * 2f * num9;
                        projectile.velocity = Utils.RotatedBy(vector3, (double)(projectile.ai[0] + 1.57079637f), default(Vector2)) * num9;
                        projectile.rotation = Utils.ToRotation(projectile.velocity) + 1.57079637f;
                        if (Main.rand.Next(5) == 0 && Main.netMode != 1 && projectile.localAI[1] == 0f)
                        {
                            float num13 = (float)Main.rand.Next(-1, 1) * 1.04719758f / 3f;
                            Vector2 vector5 = Utils.RotatedBy(Utils.ToRotationVector2(projectile.ai[0]), (double)num13, default(Vector2)) * projectile.velocity.Length();
                            int num14 = Projectile.NewProjectile(projectile.Center.X - vector5.X, projectile.Center.Y - vector5.Y, vector5.X, vector5.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, Utils.ToRotation(vector5) + 1000f, projectile.ai[1]);
                            Main.projectile[num14].timeLeft = 240;
                        }
                    }
                }
            }
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity.X = 0f;
            projectile.velocity.Y = 0f;            
            return false;
        }
    }
}
