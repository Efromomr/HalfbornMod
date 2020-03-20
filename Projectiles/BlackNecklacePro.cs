using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class BlackNecklacePro : ParentNecklacePro
    {
        public override string SpawnProj()
        {
            string str = "BlackNecklacePro2";
            return str;
        }
        public override int BuffOnHit()
        {
            int num = 153;
            return num;
        }
    }
}
