using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HalfbornMod.NPCs
{
    public abstract class Elemental : ModNPC
    {

        public override void SetDefaults()
        {
            npc.lifeMax = 120;
            npc.damage = 16;
            npc.defense = 10;
            npc.scale = 1.2f;
            npc.width = 36;
            npc.height = 36;
            npc.aiStyle = 14;
            npc.scale = 1f;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath37;
            npc.alpha = 40;
            npc.noGravity = true;
            npc.knockBackResist = 0.0f;
            npc.value = (float)Item.buyPrice(0, 0, 6, 0);
            npc.buffImmune[20] = true;
            npc.buffImmune[70] = true;
        } 

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

         public override float SpawnChance(NPCSpawnInfo spawnInfo)
         {
             return SpawnCondition.Underground.Chance * 0.5f;
         }

        private int frame = 0;
        private double frameCounter = 0.0;
        public override void FindFrame(int frameHeight)
        {
            PlayAnimation();

            if (!playAnimation)
                return;

            ++frameCounter;
            double tick = 5.0;
            frame = (int)(frameCounter / tick);

            if (frameCounter >= (Main.npcFrameCount[npc.type]) * tick)
            { frameCounter = 0.0; frame = 0; playAnimation = false; }

            npc.frame.Y = frame * frameHeight;
        }
        private bool playAnimation = false;
        private bool PlayAnimation()
        {
            if (Main.rand.Next(2) == 0 && !playAnimation)
            {
                playAnimation = true;
                return true;
            }
            return false;
        }

        public override void AI()
        {
            Lighting.AddLight(this.npc.position, 0.25f, 0.45f, 0.8f);
            npc.TargetClosest(true);
            Vector2 vector2_1 = Main.player[this.npc.target].Center + new Vector2(this.npc.Center.X, this.npc.Center.Y);
            Vector2 vector2_2 = this.npc.Center + new Vector2(this.npc.Center.X, this.npc.Center.Y);
            this.npc.netUpdate = true;
            ++this.npc.ai[2];        
            if ((double)this.npc.ai[1] == 0.0)
            {
                if ((double)Main.player[this.npc.target].position.X < (double)this.npc.position.X && (double)this.npc.velocity.X > -8.0)
                    this.npc.velocity.X -= 0.3f;
                if ((double)Main.player[this.npc.target].position.X > (double)this.npc.position.X && (double)this.npc.velocity.X < 8.0)
                    this.npc.velocity.X += 0.3f;
                if ((double)Main.player[this.npc.target].position.Y < (double)this.npc.position.Y + 200.0)
                {
                    if ((double)this.npc.velocity.Y < 0.0)
                    {
                        if ((double)this.npc.velocity.Y > -4.0)
                            this.npc.velocity.Y -= 0.4f;
                    }
                    else
                        this.npc.velocity.Y -= 0.8f;
                }
                if ((double)Main.player[this.npc.target].position.Y > (double)this.npc.position.Y + 200.0)
                {
                    if ((double)this.npc.velocity.Y > 0.0)
                    {
                        if ((double)this.npc.velocity.Y < 4.0)
                            this.npc.velocity.Y += 0.4f;
                    }
                    else
                        this.npc.velocity.Y += 0.6f;
                }
            }
            this.npc.netUpdate = true;
        }    
    }
}
