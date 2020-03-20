using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Projectiles
{
    public class RedRingPro : ParentRingPro
    {
        public override int BuffOnHit()
        {
            int num = 30;
            return num;
        }
    }
}
