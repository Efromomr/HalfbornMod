using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HalfbornMod.Projectiles
{
    public class RedBeltPro2 : ParentBeltPro2
    {
        public override int BuffOnHit()
        {
            int num = 30;
            return num;
        }



    }
}
