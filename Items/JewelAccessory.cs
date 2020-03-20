using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Items
{
    
    public abstract class JewelAccessory : ModItem
    {
        public virtual void SafeUpdateAccessory(Player player, bool hideVisual)
        {

        }
        public sealed override void UpdateAccessory(Player player, bool hideVisual)
        {
            SafeUpdateAccessory(player, hideVisual);
            player.GetModPlayer<HalfbornPlayer>().jewelAcc = true;
        }

        public override bool CanEquipAccessory(Player player, int slot)
        {
            if (slot < 10) 
            {
                int maxAccessoryIndex = 5 + player.extraAccessorySlots;
                for (int i = 3; i < 3 + maxAccessoryIndex; i++)
                {
                    
                    if (player.GetModPlayer<HalfbornPlayer>().jewelAcc)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    
        


        
        
    }
}