using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class RedBeltPro : ParentBeltPro
    {
        public override string SpawnProj()
        {
            string str = "RedBeltPro2";
            return str;
        }
    }
}
