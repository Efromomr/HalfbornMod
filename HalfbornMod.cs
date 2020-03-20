using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace HalfbornMod
{
	class HalfbornMod : Mod
	{
        public static ModHotKey DevilTrigger;
        public static ModHotKey Swap;

        public override void Load()
        {
            HalfbornMod.DevilTrigger = RegisterHotKey("Demon Power", "G");
            HalfbornMod.Swap = RegisterHotKey("Swap Power", "L");
            if (!Main.dedServ)
            {                            
                Filters.Scene["Halfborn:MageDemonSky"] = new Filter(new DemonScreenShaderData("FilterMiniTower").UseColor(0f, 0f, 0.5f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Halfborn:MageDemonSky"] = new DemonSky();
                Filters.Scene["Halfborn:WarDemonSky"] = new Filter(new DemonScreenShaderData("FilterMiniTower").UseColor(0.5f, 0f, 0f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Halfborn:WarDemonSky"] = new DemonSky();
                Filters.Scene["Halfborn:ShootDemonSky"] = new Filter(new DemonScreenShaderData("FilterMiniTower").UseColor(0f, 0.5f, 0f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Halfborn:ShootDemonSky"] = new DemonSky();
                Filters.Scene["Halfborn:SummonDemonSky"] = new Filter(new DemonScreenShaderData("FilterMiniTower").UseColor(0f, 0f, 0.8f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Halfborn:SummonDemonSky"] = new DemonSky();
            }
			AddEquipTexture(null, EquipType.Legs, "HasturLeggings_Legs", "HalfbornMod/Items/Vanity/HasturLeggings_Legs");
        }

        public override void Unload ()
        {
            HalfbornMod.DevilTrigger = null;
            HalfbornMod.Swap = null;
        }
        public HalfbornMod()
		{
		}
	}
}
