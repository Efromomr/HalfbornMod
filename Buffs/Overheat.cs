using System;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Buffs
{

    public class Overheat : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Overheating");
            Description.SetDefault("You cannot use magic weapons");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<HalfbornPlayer>().weaponOff = true;
        }


    }
}
