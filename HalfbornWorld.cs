using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace HalfbornMod
{

    public class HalfbornWorld : ModWorld
    {


        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {                   
            int num = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Random Gems"));
            if (num != -1)
            {
                tasks.Insert(num + 1, new PassLegacy("Halfborn Mod: Random Gems", new WorldGenLegacyMethod(this.RandomGems)));
            }
           
           
           
        }

        private void RandomGems(GenerationProgress progress)
        {
            int num = (int)((float)Main.maxTilesX * 0.12f);
            int tile = mod.TileType("CrystalTiles");
            for (int i = 0; i < num; i++)
            {
                int x = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
                int y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 300);
                Tile tileSafely = Framing.GetTileSafely(x, y);
                if (!tileSafely.active() && !tileSafely.lava() && !Main.wallDungeon[(int)tileSafely.wall] && tileSafely.wall != 27 && TileLoader.CanPlace(x, y, tile))
                {
                    WorldGen.PlaceTile(x, y, tile, true, false, -1, 0);
                    tileSafely.frameX = (short)(WorldGen.genRand.Next(1) * 18);
                }
            }
        }
    }
}