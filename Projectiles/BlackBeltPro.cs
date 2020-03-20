using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Projectiles
{
    public class BlackBeltPro : ParentBeltPro
    {
        public override string SpawnProj()
        {
            string str = "BlackBeltPro2";
            return str;
        }
    }
}
