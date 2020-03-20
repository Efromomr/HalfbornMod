using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class WhiteNecklacePro : ParentNecklacePro
    {
        public override string SpawnProj()
        {
            string str = "WhiteNecklacePro2";
            return str;
        }
        public override int BuffOnHit()
        {
            int num = 36;
            return num;
        }
    }
}
