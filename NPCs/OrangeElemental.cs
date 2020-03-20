using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HalfbornMod.NPCs
{
    public class OrangeElemental : Elemental
    {
        public override void SetStaticDefaults()
        {
            this.DisplayName.SetDefault("Orange Elemental");
            Main.npcFrameCount[npc.type] = 6;
        }
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
            banner = npc.type;
            bannerItem = mod.ItemType("OrangeElementalBanner");
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (this.npc.life <= 0)
            {
                for (int index = 0; index < 25; ++index)
                    Dust.NewDust(npc.position, npc.width, npc.height, 30, 2.5f * (float)hitDirection, -3f, 0, new Color(), 1.6f);
                for (int index = 0; index < 5; ++index)
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OrangeElemGore"), 1f);
            }
            else
            {
                for (int index = 0; (double)index < damage / (double)npc.lifeMax * 50.0; ++index)
                    Dust.NewDust(npc.position, npc.width, npc.height, 25, (float)hitDirection, -1f, 0, new Color(), 0.6f);
            }
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(15) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OrangeShard"), Main.rand.Next(1, 2), false, 0, false, false);
        }
    }
}