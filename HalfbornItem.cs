using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace HalfbornMod
{
    public class HalfbornItem : GlobalItem
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
        // Player player = Main.player[Main.myPlayer];
        Vector2 offset = new Vector2(10, -10);
        public override void UseStyle(Item item, Player player)
        {
            if (player.GetModPlayer<HalfbornPlayer>().demonForm)
            {
                if (player.HeldItem.useStyle != 1) HalfbornPlayer.modifyPlayerItemLocation(player, -5, 10);
                else
                {
                    if (player.itemTime == 0)
                    {
                       // player.itemTime = (int)(item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item));
                    }
                    else if (player.itemTime == (int)(item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item)) / 3)
                    {
                        if (player.bodyFrame.Y >= 1 * player.bodyFrame.Height && player.bodyFrame.Y <= 3 * player.bodyFrame.Height) HalfbornPlayer.modifyPlayerItemLocation(player, -12, -14);

                    }
                }
            }
        }
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.GetModPlayer<HalfbornPlayer>().demonForm)
            {
                position += offset;
            }
            return true;
        }
		
		public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && Main.rand.Next(30) == 0)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        player.QuickSpawnItem(mod.ItemType("EfromomrsHood"));
                        player.QuickSpawnItem(mod.ItemType("EfromomrsRobe"));
                        player.QuickSpawnItem(mod.ItemType("EfromomrsBoots"));
                        break;
					case 1:
                        player.QuickSpawnItem(mod.ItemType("CursedKnightHelmet"));
                        player.QuickSpawnItem(mod.ItemType("CursedKnightBreastplate"));
                        player.QuickSpawnItem(mod.ItemType("CursedKnightGreaves"));
                        break;
					case 2:
                        player.QuickSpawnItem(mod.ItemType("MeuRansHood"));
                        player.QuickSpawnItem(mod.ItemType("MeuRansBreastplate"));
                        player.QuickSpawnItem(mod.ItemType("MeuRansGreaves"));
                        break;
					case 3:
                        player.QuickSpawnItem(mod.ItemType("HasturHood"));
                        player.QuickSpawnItem(mod.ItemType("HasturRobe"));
                        break;
				    case 4:
                        player.QuickSpawnItem(mod.ItemType("MrPigeonsMask"));
                        player.QuickSpawnItem(mod.ItemType("MrPigeonsJacket"));
                        player.QuickSpawnItem(mod.ItemType("MrPigeonsBoots"));
                        break;
					case 5:
                        player.QuickSpawnItem(mod.ItemType("OctodudesMask"));
                        player.QuickSpawnItem(mod.ItemType("OctodudesHat"));
                        break;
					case 6:
                        player.QuickSpawnItem(mod.ItemType("BripesHeadgear"));
                        player.QuickSpawnItem(mod.ItemType("BripesChestplate"));
                        player.QuickSpawnItem(mod.ItemType("BripesBoots"));
                        break;
                }
            }
        }
    }
}