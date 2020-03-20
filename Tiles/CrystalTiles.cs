using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HalfbornMod.Tiles
{

    public class CrystalTiles : ModTile
    {

        public override void SetDefaults()
        {
            Main.tileFrameImportant[(int)Type] = true;
            Main.tileObsidianKill[(int)Type] = true;
            Main.tileShine2[(int)Type] = true;
            Main.tileShine[(int)Type] = 500;
            Main.tileSpelunker[(int)Type] = true;
            dustType = 218;
            ModTranslation modTranslation = CreateMapEntryName("Red Crystal");
            modTranslation.SetDefault("Red Crystal");
            AddMapEntry(new Color(166, 0, 0), modTranslation);
            ModTranslation modTranslation1 = CreateMapEntryName("Orange Crystal");
            modTranslation1.SetDefault("Orange Crystal");
            AddMapEntry(new Color(255, 122, 0), modTranslation1);
            ModTranslation modTranslation2 = CreateMapEntryName("Yellow Crystal");
            modTranslation2.SetDefault("Yellow Crystal");
            AddMapEntry(new Color(255, 0, 226), modTranslation2);
            ModTranslation modTranslation3 = CreateMapEntryName("Green Crystal");
            modTranslation3.SetDefault("Green Crystal");
            AddMapEntry(new Color(0, 142, 0), modTranslation3);
            ModTranslation modTranslation4 = CreateMapEntryName("Blue Crystal");
            modTranslation4.SetDefault("Blue Crystal");
            AddMapEntry(new Color(255, 0, 0), modTranslation4);
            ModTranslation modTranslation5 = CreateMapEntryName("Black Crystal");
            modTranslation5.SetDefault("Black Crystal");
            AddMapEntry(new Color(0, 0, 0), modTranslation5);
            ModTranslation modTranslation6 = CreateMapEntryName("White Crystal");
            modTranslation6.SetDefault("White Crystal");
            AddMapEntry(new Color(255, 255, 255), modTranslation6);

        }


        public override ushort GetMapOption(int i, int j)
        {
            return (ushort)(Main.tile[i, j].frameX / 18);
        }


        public override bool Drop(int i, int j)
        {
            int num = 0;
            switch (Main.tile[i, j].frameX / 18)
            {
                case 0:
                    num = mod.ItemType("RedShard");
                    break;
                case 1:
                    num = mod.ItemType("OrangeShard");
                    break;
                case 2:
                    num = mod.ItemType("YellowShard");
                    break;
                case 3:
                    num = mod.ItemType("GreenShard");
                    break;
                case 4:
                    num = mod.ItemType("BlueShard");
                    break;
                case 5:
                    num = mod.ItemType("BlackShard");
                    break;
                case 6:
                    num = mod.ItemType("WhiteShard");
                    break;
            }
            if (num != 0)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, num, 1, false, 0, false, false);
            }
            return true;
        }


        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].frameX / 18)
            {
                case 1:
                    type = 36;
                    break;
                case 2:
                    type = 69;
                    break;
                case 3:
                    type = 129;
                    break;
                case 4:
                    type = 34;
                    break;
                case 5:
                    type = 36;
                    break;
                case 6:
                    type = 34;
                    break;
            }
            return true;
        }


        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            Tile tileSafely = Framing.GetTileSafely(i, j);
            Tile tileSafely2 = Framing.GetTileSafely(i, j - 1);
            Tile tileSafely3 = Framing.GetTileSafely(i, j + 1);
            Tile tileSafely4 = Framing.GetTileSafely(i - 1, j);
            Tile tileSafely5 = Framing.GetTileSafely(i + 1, j);
            int num = -1;
            int num2 = -1;
            int num3 = -1;
            int num4 = -1;
            if (tileSafely2.active() && !tileSafely2.bottomSlope())
            {
                num2 = (int)tileSafely2.type;
            }
            if (tileSafely3.active() && !tileSafely3.halfBrick() && !tileSafely3.topSlope())
            {
                num = (int)tileSafely3.type;
            }
            if (tileSafely4.active())
            {
                num3 = (int)tileSafely4.type;
            }
            if (tileSafely5.active())
            {
                num4 = (int)tileSafely5.type;
            }
            int num5 = WorldGen.genRand.Next(3) * 18;
            if (num >= 0 && Main.tileSolid[num] && !Main.tileSolidTop[num])
            {
                if (tileSafely.frameY < 0 || tileSafely.frameY > 36)
                {
                    tileSafely.frameY = (short)num5;
                }
            }
            else if (num3 >= 0 && Main.tileSolid[num3] && !Main.tileSolidTop[num3])
            {
                if (tileSafely.frameY < 108 || tileSafely.frameY > 54)
                {
                    tileSafely.frameY = (short)(108 + num5);
                }
            }
            else if (num4 >= 0 && Main.tileSolid[num4] && !Main.tileSolidTop[num4])
            {
                if (tileSafely.frameY < 162 || tileSafely.frameY > 198)
                {
                    tileSafely.frameY = (short)(162 + num5);
                }
            }
            else if (num2 >= 0 && Main.tileSolid[num2] && !Main.tileSolidTop[num2])
            {
                if (tileSafely.frameY < 54 || tileSafely.frameY > 90)
                {
                    tileSafely.frameY = (short)(54 + num5);
                }
            }
            else
            {
                WorldGen.KillTile(i, j, false, false, false);
            }
            return true;
        }


        public override bool CanPlace(int i, int j)
        {
            return WorldGen.SolidTile(i - 1, j) || WorldGen.SolidTile(i + 1, j) || WorldGen.SolidTile(i, j - 1) || WorldGen.SolidTile(i, j + 1);
        }


        public override void PlaceInWorld(int i, int j, Item item)
        {
            Main.tile[i, j].frameX = (short)(item.placeStyle * 18);
            NetMessage.SendTileSquare(-1, i, j, 1, 0);
        }


        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            if (Main.tile[i, j].frameY / 18 < 3)
            {
                offsetY = 2;
            }
        }
    }
}
