using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HalfbornMod
{
    public class HalfbornNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        Player player = Main.player[Main.myPlayer];
        public bool onlycrit;
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == 113)
            {
                if (player.GetModPlayer<HalfbornPlayer>().demonPower == 1)
                {
                    player.GetModPlayer<HalfbornPlayer>().demonPower = 2;
                    Main.NewText("You are slowly getting stronger...", new Color(255, 0, 0));
                }
            }
            if (npc.type == 262)
            {
                if (player.GetModPlayer<HalfbornPlayer>().demonPower == 2)
                {
                    player.GetModPlayer<HalfbornPlayer>().demonPower = 3;
                    Main.NewText("Your power is now unlimited!", Color.IndianRed);
                }
            }
            if (npc.type == 62)
            {
                if (Main.rand.Next(30) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DemonAxe"), 1, false, 0, false, false);
            }
            if (npc.type == 66)
            {
                if (Main.rand.Next(30) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DemonStaff"), 1, false, 0, false, false);
            }
            if (npc.type == 24)
            {
                if (Main.rand.Next(30) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DemonBow"), 1, false, 0, false, false);
            }
            if (npc.type == 60)
            {
                if (Main.rand.Next(30) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DemonAmulet"), 1, false, 0, false, false);
            }
        }
        public override void ResetEffects(NPC npc)
        {
            onlycrit = false;
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (onlycrit) crit = true;

        }
    }
}