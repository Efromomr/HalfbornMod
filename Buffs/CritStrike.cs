using System;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Buffs
{

    public class CritStrike : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Critical Strike");
            Description.SetDefault("This enemy gets only critical strikes");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }


        public override void Update(Player player, ref int buffIndex)
        {
        }


        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<HalfbornNPC>().onlycrit = true;
        }
    }
}
