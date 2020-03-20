using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Buffs
{

    public class MagicWeapon : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Magic weapon");
            Description.SetDefault("You can now use Universal Item as melee weapon");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<HalfbornPlayer>().weaponOn = true;
            if (player.buffTime[buffIndex] == 60)
            {
                player.AddBuff(ModContent.BuffType<Overheat>(), 300, true);
            }
        }

    }
}
