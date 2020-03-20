using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class OrangeNecklacePro : ParentNecklacePro
    {
        public override string SpawnProj()
        {
            string str = "OrangeNecklacePro2";
            return str;
        }
        public override int BuffOnHit()
        {
            int num = 24;
            return num;
        }
    }
}
