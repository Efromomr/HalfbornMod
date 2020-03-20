using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace HalfbornMod
{
    public class DemonScreenShaderData : ScreenShaderData
    {
        
            private int k;

            public DemonScreenShaderData(string passName) : base(passName)
            { }

            private void UpdatePuritySpiritIndex()
            {
                return;
                k = -1;
            }

            public override void Apply()
            {
                UpdatePuritySpiritIndex();
                base.Apply();
            }
        
    }
}