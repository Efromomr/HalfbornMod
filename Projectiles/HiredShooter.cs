using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace HalfbornMod.Projectiles
{
	
	public abstract class HiredShooter : Minion
	{
		
		public virtual void CreateDust()
		{
		}

		
		public virtual void SelectFrame()
		{
		}

		
		public override void Behavior()
		{
			Player player = Main.player[projectile.owner];
			float num = (float)projectile.width * this.spacingMult;
			for (int i = 0; i < 1000; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (i != projectile.whoAmI && projectile.active && projectile.owner == projectile.owner && projectile.type == projectile.type && Math.Abs(projectile.position.X - projectile.position.X) + Math.Abs(projectile.position.Y - projectile.position.Y) < num)
				{
					if (projectile.position.X < Main.projectile[i].position.X)
					{
						Projectile projectile2 = projectile;
						projectile2.velocity.X = projectile2.velocity.X - this.idleAccel;
					}
					else
					{
						Projectile projectile3 = projectile;
						projectile3.velocity.X = projectile3.velocity.X + this.idleAccel;
					}
					if (projectile.position.Y < Main.projectile[i].position.Y)
					{
						Projectile projectile4 = projectile;
						projectile4.velocity.Y = projectile4.velocity.Y - this.idleAccel;
					}
					else
					{
						Projectile projectile5 = projectile;
						projectile5.velocity.Y = projectile5.velocity.Y + this.idleAccel;
					}
				}
			}
			Vector2 value = projectile.position;
			float num2 = this.viewDist;
			bool flag = false;
			projectile.tileCollide = true;
			for (int j = 0; j < 200; j++)
			{
				NPC npc = Main.npc[j];
				if (npc.CanBeChasedBy(this, false))
				{
					float num3 = Vector2.Distance(npc.Center, projectile.Center);
					if ((num3 < num2 || !flag) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
					{
						num2 = num3;
						value = npc.Center;
						flag = true;
					}
				}
			}
			if (Vector2.Distance(player.Center, projectile.Center) > (flag ? 1000f : 500f))
			{
				projectile.ai[0] = 1f;
				projectile.netUpdate = true;
			}
			if (projectile.ai[0] == 1f)
			{
				projectile.tileCollide = false;
			}
			if (flag && projectile.ai[0] == 0f)
			{
				Vector2 value2 = value - projectile.Center;
				if (value2.Length() > this.chaseDist)
				{
					value2.Normalize();
					projectile.velocity = (projectile.velocity * this.inertia + value2 * this.chaseAccel) / (this.inertia + 1f);
				}
				else
				{
					projectile.velocity *= (float)Math.Pow(0.97, 40.0 / (double)this.inertia);
				}
			}
			else
			{
				if (!Collision.CanHitLine(projectile.Center, 1, 1, player.Center, 1, 1))
				{
					projectile.ai[0] = 1f;
				}
				float num4 = 6f;
				if (projectile.ai[0] == 1f)
				{
					num4 = 15f;
				}
				Vector2 center = projectile.Center;
				Vector2 vector = player.Center - center;
				projectile.netUpdate = true;
				int num5 = 1;
				for (int k = 0; k < projectile.whoAmI; k++)
				{
					if (Main.projectile[k].active && Main.projectile[k].owner == projectile.owner && Main.projectile[k].type == projectile.type)
					{
						num5++;
					}
				}
				vector.X -= (float)((10 + num5 * 40) * player.direction);
				vector.Y -= 70f;
				float num6 = vector.Length();
				if (num6 > 200f && num4 < 9f)
				{
					num4 = 9f;
				}
				if (num6 < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
				{
					projectile.ai[0] = 0f;
					projectile.netUpdate = true;
				}
				if (num6 > 2000f)
				{
					projectile.Center = player.Center;
				}
				if (num6 > 48f)
				{
					vector.Normalize();
					vector *= num4;
					float num7 = this.inertia / 2f;
					projectile.velocity = (projectile.velocity * num7 + vector) / (num7 + 1f);
				}
				else
				{
					projectile.direction = Main.player[projectile.owner].direction;
					projectile.velocity *= (float)Math.Pow(0.9, 40.0 / (double)this.inertia);
				}
			}
			projectile.rotation = projectile.velocity.X * 0.05f;
			this.SelectFrame();
			this.CreateDust();
			if (projectile.velocity.X > 0f)
			{
				projectile.spriteDirection = (projectile.direction = -1);
			}
			else if (projectile.velocity.X < 0f)
			{
				projectile.spriteDirection = (projectile.direction = 1);
			}
			projectile.ai[1] += 1f;
			if (projectile.ai[0] == 0f && flag)
			{
				if ((value - projectile.Center).X > 0f)
				{
					projectile.spriteDirection = (projectile.direction = -1);
				}
				else if ((value - projectile.Center).X < 0f)
				{
					projectile.spriteDirection = (projectile.direction = 1);
				}
				if (projectile.ai[1] >= 0f && Main.myPlayer == projectile.owner)
				{
					Vector2 vector2 = value - projectile.Center;
					if (vector2 == Vector2.Zero)
					{
						vector2 = new Vector2(0f, 1f);
					}
					vector2.Normalize();
					vector2 *= this.shootSpeed;
					int num8 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X, vector2.Y, this.shoot, (int)(40f), projectile.knockBack, Main.myPlayer, 0f, 0f);
					Main.projectile[num8].timeLeft = 300;
					Main.projectile[num8].netUpdate = true;
					projectile.netUpdate = true;
					projectile.ai[1] = (float)(-(float)this.shootCool);
				}
			}
		}

		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = true;
			return true;
		}

		
		protected float idleAccel = 0.05f;

		
		protected float spacingMult = 1f;

		
		protected float viewDist = 100f;

		
		protected float chaseDist = 250f;

		
		protected float chaseAccel = 5f;

		
		protected float inertia = 40f;

		
		protected int shootCool = 45;

		
		protected float shootSpeed;

		
		protected int shoot;
	}
}
