using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class BlueNecklacePro : ParentNecklacePro
    {
        public override string SpawnProj()
        {
            string str = "BlueNecklacePro2";
            return str;
        }
        public override int BuffOnHit()
        {
            int num = 44;
            return num;
        }
    }
}
