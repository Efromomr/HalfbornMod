using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class RedNecklacePro : ParentNecklacePro
    {
        public override string SpawnProj()
        {
            string str = "RedNecklacePro2";
            return str;
        }
        public override int BuffOnHit()
        {
            int num = 30;
            return num;
        }
    }
}
