using System;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Buffs
{

    public class DemonMinionBuff : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Demon");
            Description.SetDefault("Summons a demon that guards you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.DemonMinion>()] > 0)
            {
                player.GetModPlayer<HalfbornPlayer>().demonMinion = true;
            }
            if (!player.GetModPlayer<HalfbornPlayer>().demonMinion)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }
            player.buffTime[buffIndex] = 18000;
        }
    }
}
