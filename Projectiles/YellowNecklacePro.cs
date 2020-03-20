using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class YellowNecklacePro : ParentNecklacePro
    {
        public override string SpawnProj()
        {
            string str = "YellowNecklacePro2";
            return str;
        }
        public override int BuffOnHit()
        {
            int num = 32;
            return num;
        }
    }
}
