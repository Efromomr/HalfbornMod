using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{

    public class BlueWeapon : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 30;
            projectile.scale = 1.1f;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.aiStyle = -1;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(mod.GetTexture("Glow/BlueWeapon_Glow"), projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(11f, 11f), 1f, SpriteEffects.None, 0f);
        }


        int timer;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            timer++;
            if (timer > 5)
            {
                timer = 0;
                projectile.Kill();
            }
        }

        public override void AI()
        {
            Lighting.AddLight(this.projectile.position, 0.08f, 0.2f, 0.2f);
            if (Main.player[this.projectile.owner].dead)
            {
                this.projectile.Kill();
            }
            else
            {
                Main.player[this.projectile.owner].itemAnimation = 10;
                Main.player[this.projectile.owner].itemTime = 10;
                if ((double)this.projectile.position.X + (double)(this.projectile.width / 2) > (double)Main.player[this.projectile.owner].position.X + (double)(Main.player[this.projectile.owner].width / 2))
                {
                    Main.player[this.projectile.owner].ChangeDir(1);
                    this.projectile.direction = 1;
                }
                else
                {
                    Main.player[this.projectile.owner].ChangeDir(-1);
                    this.projectile.direction = -1;
                }
                Vector2 mountedCenter = Main.player[this.projectile.owner].MountedCenter;
                Vector2 vector2_1 = new Vector2(this.projectile.position.X + (float)this.projectile.width * 0.5f, this.projectile.position.Y + (float)this.projectile.height * 0.5f);
                float num1 = mountedCenter.X - vector2_1.X;
                float num2 = mountedCenter.Y - vector2_1.Y;
                float num3 = (float)Math.Sqrt((double)num1 * (double)num1 + (double)num2 * (double)num2);
                if ((double)this.projectile.ai[0] == 0.0)
                {
                    float num4 = 160f * 1.65f;
                    this.projectile.tileCollide = true;
                    if ((double)num3 > (double)num4)
                    {
                        this.projectile.ai[0] = 1f;
                        this.projectile.netUpdate = true;
                    }
                    else if (!Main.player[this.projectile.owner].channel)
                    {
                        if ((double)this.projectile.velocity.Y < 0.0)
                            this.projectile.velocity.Y = this.projectile.velocity.Y * 0.9f;
                        this.projectile.velocity.Y = this.projectile.velocity.Y + 1f;
                        this.projectile.velocity.X = this.projectile.velocity.X * 0.9f;
                    }
                }
                else if ((double)this.projectile.ai[0] == 1.0)
                {
                    float num4 = 14f / Main.player[this.projectile.owner].meleeSpeed;
                    float num5 = 0.9f / Main.player[this.projectile.owner].meleeSpeed;
                    float num6 = 300f * 1.5f;
                    float num7 = num4 * 1.5f;
                    float num8 = num5 * 1.5f;
                    double num9 = (double)Math.Abs(num1);
                    double num10 = (double)Math.Abs(num2);
                    if ((double)this.projectile.ai[1] == 1.0)
                        this.projectile.tileCollide = false;
                    if (!Main.player[this.projectile.owner].channel || (double)num3 > (double)num6 || !this.projectile.tileCollide)
                    {
                        this.projectile.ai[1] = 1f;
                        if (this.projectile.tileCollide)
                            this.projectile.netUpdate = true;
                        this.projectile.tileCollide = false;
                        if ((double)num3 < 20.0)
                            this.projectile.Kill();
                    }
                    if (!this.projectile.tileCollide)
                        num8 *= 2f;
                    int num11 = 60;
                    if ((double)num3 > (double)num11 || !this.projectile.tileCollide)
                    {
                        float num12 = num7 / num3;
                        num1 *= num12;
                        num2 *= num12;
                        Vector2 vector2_2 = new Vector2(this.projectile.velocity.X, this.projectile.velocity.Y);
                        float num13 = num1 - this.projectile.velocity.X;
                        float num14 = num2 - this.projectile.velocity.Y;
                        float num15 = (float)Math.Sqrt((double)num13 * (double)num13 + (double)num14 * (double)num14);
                        float num16 = num8 / num15;
                        float num17 = num13 * num16;
                        float num18 = num14 * num16;
                        this.projectile.velocity.X = this.projectile.velocity.X * 0.98f;
                        this.projectile.velocity.Y = this.projectile.velocity.Y * 0.98f;
                        this.projectile.velocity.X = this.projectile.velocity.X + num17;
                        this.projectile.velocity.Y = this.projectile.velocity.Y + num18;
                    }
                    else
                    {
                        if ((double)Math.Abs(this.projectile.velocity.X) + (double)Math.Abs(this.projectile.velocity.Y) < 6.0)
                        {
                            this.projectile.velocity.X = this.projectile.velocity.X * 0.96f;
                            this.projectile.velocity.Y = this.projectile.velocity.Y + 0.2f;
                        }
                        if ((double)Main.player[this.projectile.owner].velocity.X == 0.0)
                            this.projectile.velocity.X = this.projectile.velocity.X * 0.96f;
                    }
                }
                projectile.rotation = 0f;
       
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("HalfbornMod/Projectiles/Chain");
            Vector2 center = this.projectile.Center;
            Vector2 mountedCenter = Main.player[this.projectile.owner].MountedCenter;
            Rectangle? sourceRectangle = new Rectangle?();
            Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
            float height = (float)texture.Height;
            Vector2 vector2_1 = mountedCenter - center;
            float rotation = (float)Math.Atan2((double)vector2_1.Y, (double)vector2_1.X) - 1.57f;
            bool flag = true;
            if (float.IsNaN(center.X) && float.IsNaN(center.Y))
                flag = false;
            if (float.IsNaN(vector2_1.X) && float.IsNaN(vector2_1.Y))
                flag = false;
            while (flag)
            {
                if ((double)vector2_1.Length() < (double)height + 1.0)
                {
                    flag = false;
                }
                else
                {
                    Vector2 vector2_2 = vector2_1;
                    vector2_2.Normalize();
                    center += vector2_2 * height;
                    vector2_1 = mountedCenter - center;
                    Color alpha = this.projectile.GetAlpha(Lighting.GetColor((int)center.X / 16, (int)((double)center.Y / 16.0)));
                    Main.spriteBatch.Draw(texture, center - Main.screenPosition, sourceRectangle, alpha, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                }
            }
            return true;
        }
          public override void PostAI()
          {
              Vector2 vector2 = Main.player[projectile.owner].MountedCenter - projectile.Center;
              projectile.rotation = (float)Math.Atan2((double)vector2.Y, (double)vector2.X) ;
          }
    }
}
