using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class GreenNecklacePro : ParentNecklacePro
    {
        public override string SpawnProj()
        {
            string str = "GreenNecklacePro2";
            return str;
        }
        public override int BuffOnHit()
        {
            int num = 20;
            return num;
        }
    }
}
