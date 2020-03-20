using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


namespace HalfbornMod
{
    public class HalfbornPlayer : ModPlayer
    {
        public bool blueRing;
        public bool blackRing;
        public bool greenRing;
        public bool orangeRing;
        public bool yellowRing;
        public bool redRing;
        public bool whiteRing;
        public bool blueBelt;
        public bool blackBelt;
        public bool greenBelt;
        public bool orangeBelt;
        public bool yellowBelt;
        public bool redBelt;
        public bool whiteBelt;
        public bool blueNecklace;
        public bool blackNecklace;
        public bool greenNecklace;
        public bool orangeNecklace;
        public bool yellowNecklace;
        public bool redNecklace;
        public bool whiteNecklace;
        public bool blueGlove;
        public bool blackGlove;
        public bool greenGlove;
        public bool orangeGlove;
        public bool yellowGlove;
        public bool redGlove;
        public bool whiteGlove;
        public bool blueWeapon;
        public bool blackWeapon;
        public bool greenWeapon;
        public bool orangeWeapon;
        public bool yellowWeapon;
        public bool redWeapon;
        public bool whiteWeapon;
        public bool weaponOn;
        public bool weaponOff;
        public bool jewelAcc;
        public bool anyGlove;
        public bool anyBelt;
        public bool anyNecklace;
        public bool anyRing;
        public bool anyBlack;
        public bool anyBlue;
        public bool anyGreen;
        public bool anyOrange;
        public bool anyRed;
        public bool anyWhite;
        public bool anyYellow;
        public bool demonForm;
        public int demonPower;
        public int currentPower;
        public bool warDemon;
        public bool mageDemon;
        public bool shootDemon;
        public bool summonDemon;
        public bool demonMinion;

        public override void Initialize()
        {
            warDemon = false;
            mageDemon = false;
            shootDemon = false;
            summonDemon = false;
            demonPower = 0;
			currentPower = 1;
        }

        public override TagCompound Save()
        {

            return new TagCompound {
                {"warDemon", warDemon},
                {"mageDemon", mageDemon},
                {"shootDemon", shootDemon},
                {"summonDemon", summonDemon},
                {"demonPower", demonPower},
                {"currentPower", currentPower},
            };
        }

        public override void Load(TagCompound tag)
        {
            warDemon = tag.GetBool("warDemon");
            mageDemon = tag.GetBool("mageDemon");
            shootDemon = tag.GetBool("shootDemon");
            summonDemon = tag.GetBool("summonDemon");
            demonPower = tag.GetInt("demonPower");
            currentPower = tag.GetInt("currentPower");

        }
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].Name == "HeldItem")
                {
                    layers.Insert(i + 1, HalfbornPlayer.WeaponLayer);
                    break;
                }
            }
            if (demonForm)
            {
                foreach (PlayerLayer playerLayer in layers)
                {
                    if (playerLayer != PlayerLayer.MiscEffectsFront && playerLayer != PlayerLayer.HeldItem && playerLayer != PlayerLayer.MiscEffectsBack)
                    {
                        playerLayer.visible = false;
                    }
                }
            }
            HalfbornPlayer.WeaponLayer.visible = true;

            HalfbornPlayer.MiscEffectsFront.visible = true;
            layers.Add(HalfbornPlayer.MiscEffectsFront);
            HalfbornPlayer.MiscEffectsBack.visible = true;
            layers.Insert(1, HalfbornPlayer.MiscEffectsBack);
        }

        public override void ResetEffects()
        {
            blueRing = false;
            blackRing = false;
            greenRing = false;
            orangeRing = false;
            yellowRing = false;
            redRing = false;
            whiteRing = false;
            blueBelt = false;
            blackBelt = false;
            greenBelt = false;
            orangeBelt = false;
            yellowBelt = false;
            redBelt = false;
            whiteBelt = false;
            blueNecklace = false;
            blackNecklace = false;
            greenNecklace = false;
            orangeNecklace = false;
            yellowNecklace = false;
            redNecklace = false;
            whiteNecklace = false;
            blueGlove = false;
            blackGlove = false;
            greenGlove = false;
            orangeGlove = false;
            yellowGlove = false;
            redGlove = false;
            whiteGlove = false;
            weaponOff = false;
            weaponOn = false;
            jewelAcc = false;
            anyGlove = false;
            anyBelt = false;
            anyNecklace = false;
            anyRing = false;
            anyBlack = false;
            anyBlue = false;
            anyGreen = false;
            anyOrange = false;
            anyRed = false;
            anyWhite = false;
            anyYellow = false;
            demonMinion = false;
        }
        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(this.mod.ItemType("UniversalItem"), false);
            item.stack = 1;
            items.Add(item);
            Item item1 = new Item();
            item1.SetDefaults(this.mod.ItemType("EmptyTalon"), false);
            item1.stack = 1;
            items.Add(item1);
        }

        public static void modifyPlayerItemLocation(Player player, float X, float Y)
        {
            float cosRot = (float)Math.Cos(player.itemRotation);
            float sinRot = (float)Math.Sin(player.itemRotation);

            player.itemLocation.X = player.itemLocation.X + (X * cosRot * player.direction) + (Y * sinRot * player.gravDir);
            player.itemLocation.Y = player.itemLocation.Y + (X * sinRot * player.direction) - (Y * cosRot * player.gravDir);
        }

        public static readonly PlayerLayer MiscEffectsBack = new PlayerLayer("HalfbornMod", "MiscEffectsBack", PlayerLayer.MiscEffectsBack, (Action<PlayerDrawInfo>)(drawInfo =>
        {
            if ((double)drawInfo.shadow != 0.0)
                return;
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = Terraria.ModLoader.ModLoader.GetMod("HalfbornMod");
            HalfbornPlayer modPlayer = (HalfbornPlayer)drawPlayer.GetModPlayer(mod, "HalfbornPlayer");
            if (drawPlayer.dead)
                return;
            int num1 = 3;
            Texture2D body_texture = mod.GetTexture("Glow/DummyGlow");
            Texture2D legs_texture = mod.GetTexture("Glow/DummyGlow");
            string classname = "War"; string bossname = "";
            SpriteEffects spriteEffects = SpriteEffects.None;
            Rectangle bodyFrame = drawPlayer.bodyFrame;
            Rectangle legFrame = drawPlayer.legFrame;
            if (drawPlayer.direction < 0) spriteEffects = SpriteEffects.FlipHorizontally;
            if (modPlayer.demonForm && modPlayer.demonPower > 0)
              // if (modPlayer.mageDemon) num1 = 4;
            {
                switch (modPlayer.demonPower)
                {
                    case 1:
                        bossname = "";
                        break;
                    case 2:
                        bossname = "Hardmode";
                        break;
                    case 3:
                        bossname = "Moonlord";
                        break;
                }
                if (modPlayer.warDemon) classname = "War";
                else if (modPlayer.mageDemon) classname = "Mage";
                else if (modPlayer.shootDemon) classname = "Shoot";
                else if (modPlayer.summonDemon) classname = "Summon";

                body_texture = mod.GetTexture("Glow/" + classname + "Demon" + bossname + "_Body");
                legs_texture = mod.GetTexture("Glow/" + classname + "Demon" + bossname + "_Legs");
            }
            
            int b_num2 = body_texture.Height / 20;
            int b_num3 = (int)((double)drawInfo.position.X + 3.0 + (double)drawPlayer.width / 2.0 - (double)Main.screenPosition.X);
            int b_num4 = (int)((double)drawInfo.position.Y - (double)(5 + num1) + (double)drawPlayer.height / 2.0 - (double)Main.screenPosition.Y);
            int l_num4 = (int)((double)drawInfo.position.Y - (double)(6) + (double)drawPlayer.height / 2.0 - (double)Main.screenPosition.Y);
            DrawData drawData = new DrawData(body_texture, new Vector2((float)b_num3, (float)b_num4), new Rectangle?(bodyFrame), Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), 0.0f, new Vector2((float)body_texture.Width / 2f, (float)b_num2 / 2f), 1f, spriteEffects, 0);
            DrawData drawData1 = new DrawData(legs_texture, new Vector2((float)b_num3, (float)l_num4), new Rectangle?(legFrame), Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), 0.0f, new Vector2((float)body_texture.Width / 2f, (float)b_num2 / 2f), 1f, spriteEffects, 0);
            Main.playerDrawData.Add(drawData);
            Main.playerDrawData.Add(drawData1);
        }));
  
        public static readonly PlayerLayer MiscEffectsFront = new PlayerLayer("HalfbornMod", "MiscEffectsFront", PlayerLayer.MiscEffectsFront, (Action<PlayerDrawInfo>)(drawInfo =>
        {
            if ((double)drawInfo.shadow != 0.0)
                return;
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = Terraria.ModLoader.ModLoader.GetMod("HalfbornMod");
            HalfbornPlayer modPlayer = (HalfbornPlayer)drawPlayer.GetModPlayer(mod, "HalfbornPlayer");
            if (drawPlayer.dead)
                return;
            int num1 = 4;
            Texture2D body_texture = mod.GetTexture("Glow/DummyGlow");
            string classname = ""; string bossname = "";
            SpriteEffects spriteEffects = SpriteEffects.None;
            Rectangle bodyFrame = drawPlayer.bodyFrame;
            if (drawPlayer.direction < 0) spriteEffects = SpriteEffects.FlipHorizontally;
            // if (bodyFrame.Y / bodyFrame.Height >= 12) bodyFrame.Y = bodyFrame.Height * 8;
            if (modPlayer.demonForm && modPlayer.demonPower > 0)
            {
                switch (modPlayer.demonPower)
                {
                    case 1:
                        bossname = "";
                        break;
                    case 2:
                        bossname = "Hardmode";
                        break;
                    case 3:
                        bossname = "Moonlord";
                        break;
                }
                if (modPlayer.warDemon) classname = "War";
                else if (modPlayer.mageDemon) classname = "Mage";
                else if (modPlayer.shootDemon) classname = "Shoot";
                else if (modPlayer.summonDemon) classname = "Summon";

                body_texture = mod.GetTexture("Glow/" + classname + "Demon" + bossname + "_Arms");
            }
            int b_num2 = body_texture.Height / 20;
            int b_num3 = (int)((double)drawInfo.position.X + 3.0 + (double)drawPlayer.width / 2.0 - (double)Main.screenPosition.X);
            int b_num4 = (int)((double)drawInfo.position.Y - (double)(3 + num1) + (double)drawPlayer.height / 2.0 - (double)Main.screenPosition.Y);
            DrawData drawData = new DrawData(body_texture, new Vector2((float)b_num3, (float)b_num4), new Rectangle?(bodyFrame), Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), 0.0f, new Vector2((float)body_texture.Width / 2f, (float)b_num2 / 2f), 1f, spriteEffects, 0);           
            Main.playerDrawData.Add(drawData);

        }));
     
        public static readonly PlayerLayer WeaponLayer = new PlayerLayer("HalfbornMod", "WeaponLayer", PlayerLayer.HeldItem, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("HalfbornMod");
            HalfbornPlayer modPlayer = (HalfbornPlayer)drawPlayer.GetModPlayer(mod, "HalfbornPlayer");
            if (drawPlayer.dead || drawPlayer.itemAnimation <= 0)
            {
                return;
            }
            Texture2D Glowtexture = mod.GetTexture("Glow/DummyGlow");
            Texture2D Glowtexture2 = mod.GetTexture("Glow/DummyGlow");
            float rotOffset = 0;
            rotOffset = drawPlayer.gravDir == -1f ? rotOffset - (1.57f * drawPlayer.direction) : 0.785f * drawPlayer.direction;
            if (drawPlayer.HeldItem.type == mod.ItemType("UniversalItem"))
            {
                if (modPlayer.anyBlack) Glowtexture2 = mod.GetTexture("Glow/BlackAcc_Glow");
                if (modPlayer.anyBlue) Glowtexture2 = mod.GetTexture("Glow/BlueAcc_Glow");
                if (modPlayer.anyGreen) Glowtexture2 = mod.GetTexture("Glow/GreenAcc_Glow");
                if (modPlayer.anyOrange) Glowtexture2 = mod.GetTexture("Glow/OrangeAcc_Glow");
                if (modPlayer.anyRed) Glowtexture2 = mod.GetTexture("Glow/RedAcc_Glow");
                if (modPlayer.anyWhite) Glowtexture2 = mod.GetTexture("Glow/WhiteAcc_Glow");
                if (modPlayer.anyYellow) Glowtexture2 = mod.GetTexture("Glow/YellowAcc_Glow");

                Texture2D texture = Glowtexture2;
                Vector2 position = new Vector2((float)(int)((double)drawInfo.itemLocation.X - (double)Main.screenPosition.X), (float)(int)((double)drawInfo.itemLocation.Y - (double)Main.screenPosition.Y));
                Vector2 origin = new Vector2(drawPlayer.direction == -1 ? (float)texture.Width : 0.0f, (double)drawPlayer.gravDir == -1.0 ? 0.0f : (float)texture.Height);
                DrawData data = new DrawData(texture, position, new Rectangle?(), Color.White, drawPlayer.itemRotation + rotOffset, origin, drawPlayer.HeldItem.scale, drawInfo.spriteEffects, 0);
                Main.playerDrawData.Add(data);

                if (modPlayer.yellowGlove && modPlayer.weaponOn) { Glowtexture = mod.GetTexture("Glow/YellowWeapon"); Glowtexture2 = mod.GetTexture("Glow/YellowWeapon_Glow"); }
                if (modPlayer.blackGlove && modPlayer.weaponOn) { Glowtexture = mod.GetTexture("Glow/BlackWeapon"); Glowtexture2 = mod.GetTexture("Glow/BlackWeapon_Glow"); }
                if (modPlayer.greenGlove && modPlayer.weaponOn) { Glowtexture = mod.GetTexture("Glow/GreenWeapon"); Glowtexture2 = mod.GetTexture("Glow/GreenWeapon_Glow"); }
                if (modPlayer.redGlove && modPlayer.weaponOn) { Glowtexture = mod.GetTexture("Glow/RedWeapon"); Glowtexture2 = mod.GetTexture("Glow/RedWeapon_Glow"); }

                if (modPlayer.anyGlove)
                {
                    Texture2D texture2 = Glowtexture;
                    Vector2 position2 = new Vector2((float)(int)((double)drawInfo.itemLocation.X - (double)Main.screenPosition.X), (float)(int)((double)drawInfo.itemLocation.Y - (double)Main.screenPosition.Y));
                    Vector2 origin2 = new Vector2(drawPlayer.direction == -1 ? (float)texture2.Width : 0.0f, (double)drawPlayer.gravDir == -1.0 ? 0.0f : (float)texture2.Height);
                    DrawData data2 = new DrawData(texture2, position2, new Rectangle?(), Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), drawPlayer.itemRotation, origin2, drawPlayer.HeldItem.scale, drawInfo.spriteEffects, 0);
                    Main.playerDrawData.Add(data2);

                    Texture2D texture3 = Glowtexture2;
                    Vector2 position3 = new Vector2((float)(int)((double)drawInfo.itemLocation.X - (double)Main.screenPosition.X), (float)(int)((double)drawInfo.itemLocation.Y - (double)Main.screenPosition.Y));
                    Vector2 origin3 = new Vector2(drawPlayer.direction == -1 ? (float)texture3.Width : 0.0f, (double)drawPlayer.gravDir == -1.0 ? 0.0f : (float)texture3.Height);
                    DrawData data3 = new DrawData(texture3, position3, new Rectangle?(), Color.White, drawPlayer.itemRotation, origin3, drawPlayer.HeldItem.scale, drawInfo.spriteEffects, 0);
                    Main.playerDrawData.Add(data3);
                }
   

               
            }
            if (modPlayer.demonForm)
            {              

                     if (drawPlayer.HeldItem.type == mod.ItemType("DemonAxe"))
                     {
                         Texture2D texture2 = mod.GetTexture("Glow/DemonAxe_Glow");
                         Vector2 position2 = new Vector2((float)(int)((double)drawInfo.itemLocation.X - (double)Main.screenPosition.X), (float)(int)((double)drawInfo.itemLocation.Y - (double)Main.screenPosition.Y));
                         Vector2 origin2 = new Vector2(drawPlayer.direction == -1 ? (float)texture2.Width : 0.0f, (double)drawPlayer.gravDir == -1.0 ? 0.0f : (float)texture2.Height);
                         DrawData data4 = new DrawData(texture2, position2, new Rectangle?(), Color.White, drawPlayer.itemRotation, origin2, drawPlayer.HeldItem.scale, drawInfo.spriteEffects, 0);
                         Main.playerDrawData.Add(data4);
                     }

                     if (drawPlayer.HeldItem.type == mod.ItemType("DemonStaff"))
                     {
                         Texture2D texture = mod.GetTexture("Glow/DemonStaff_Glow");
                         Vector2 position = new Vector2((float)(int)((double)drawInfo.itemLocation.X - (double)Main.screenPosition.X), (float)(int)((double)drawInfo.itemLocation.Y - (double)Main.screenPosition.Y));
                         Vector2 origin = new Vector2(drawPlayer.direction == -1 ? (float)texture.Width : 0.0f, (double)drawPlayer.gravDir == -1.0 ? 0.0f : (float)texture.Height);
                         DrawData data4 = new DrawData(texture, position, new Rectangle?(), Color.White, drawPlayer.itemRotation + rotOffset, origin, drawPlayer.HeldItem.scale, drawInfo.spriteEffects, 0);
                         Main.playerDrawData.Add(data4);
                     }

                     /*if (drawPlayer.HeldItem.type == mod.ItemType("DemonBow"))
                     {
                         Texture2D texture = mod.GetTexture("Glow/DemonBow_Glow");
                         Vector2 position = new Vector2((float)(int)((double)drawInfo.itemLocation.X - (double)Main.screenPosition.X), (float)(int)((double)drawInfo.itemLocation.Y - (double)Main.screenPosition.Y));
                         Vector2 origin = new Vector2(drawPlayer.direction == -1 ? (float)texture.Width : 0.0f, (double)drawPlayer.gravDir == -1.0 ? 0.0f : (float)texture.Height);
                         DrawData data4 = new DrawData(texture, position, new Rectangle?(), Color.White, drawPlayer.itemRotation, origin, drawPlayer.HeldItem.scale, drawInfo.spriteEffects, 0);
                         Main.playerDrawData.Add(data4);
                     }*/

                     if (drawPlayer.HeldItem.type == mod.ItemType("DemonAmulet"))
                     {
                         Texture2D texture2 = mod.GetTexture("Glow/DemonAmulet_Glow");
                         Vector2 position2 = new Vector2((float)(int)((double)drawInfo.itemLocation.X - (double)Main.screenPosition.X), (float)(int)((double)drawInfo.itemLocation.Y - (double)Main.screenPosition.Y));
                         Vector2 origin2 = new Vector2(drawPlayer.direction == -1 ? (float)texture2.Width : 0.0f, (double)drawPlayer.gravDir == -1.0 ? 0.0f : (float)texture2.Height);
                         DrawData data4 = new DrawData(texture2, position2, new Rectangle?(), Color.White, drawPlayer.itemRotation, origin2, drawPlayer.HeldItem.scale, drawInfo.spriteEffects, 0);
                         Main.playerDrawData.Add(data4);
                     }

            }
        });

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            string className = " "; string powerName = "1";
            if (HalfbornMod.Swap.JustPressed && demonPower > 0 )
            {
                if (currentPower == 1 && demonPower > 1)
                {
                    currentPower = 2;
                    powerName = "2";
                }
                if (currentPower == 2 && demonPower > 2)
                {
                    currentPower = 3;
                    powerName = "3";
                }
                else
                {
                    currentPower = 1;
                    powerName = "1";
                }
                if (warDemon) className = "War";
                if (mageDemon) className = "Mage";
                if (shootDemon) className = "Shoot";
                if (summonDemon) className = "Summon";
                 Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType(className+"Emblem_"+powerName), 0, 0f, player.whoAmI, 0f, 0f);
            }
            if (HalfbornMod.DevilTrigger.JustPressed && warDemon && currentPower == 1  && demonForm)
            {
                player.velocity.X = -10 * player.direction;
                Projectile.NewProjectile(player.position.X, player.position.Y, 0f, -1f, 400, 0, 0f, player.whoAmI, 0f, 0f);
            }

            if (HalfbornMod.DevilTrigger.JustPressed && warDemon && currentPower == 2 && demonForm)
            {
                if (!(player.ownedProjectileCounts[612] > 0))
                {
                    Projectile.NewProjectile(player.position.X + (float)Main.rand.Next(-3, 3), player.position.Y + (float)Main.rand.Next(-3, 3), 5f, 0f, 612, 30, 10f, player.whoAmI, 0f, 0f);
                    Projectile.NewProjectile(player.position.X + (float)Main.rand.Next(-3, 3), player.position.Y + (float)Main.rand.Next(-3, 3), 5f, 0f, 612, 30, 10f, player.whoAmI, 0f, 0f);
                    Projectile.NewProjectile(player.position.X + (float)Main.rand.Next(-3, 3), player.position.Y + (float)Main.rand.Next(-3, 3), 5f, 0f, 706, 30, 10f, player.whoAmI, 0f, 0f);
                }
            }

            if (HalfbornMod.DevilTrigger.JustPressed && warDemon && currentPower == 3 && demonForm)
            {
                if (!(player.ownedProjectileCounts[706] > 0))
                {
                    Projectile.NewProjectile(player.position.X + 20f, player.position.Y - 10f + (float)Main.rand.Next(-3, 3), 5f * player.direction, 0f, 706, 70, 0f, player.whoAmI, 0f, 0f);
                    Projectile.NewProjectile(player.position.X + 20f, player.position.Y + (float)Main.rand.Next(-3, 3), 5f * player.direction, 0f, 706, 70, 0f, player.whoAmI, 0f, 0f);
                    Projectile.NewProjectile(player.position.X + 20f, player.position.Y + 10f + (float)Main.rand.Next(-3, 3), 5f * player.direction, 0f, 706, 70, 0f, player.whoAmI, 0f, 0f);
                }
            }

            if (HalfbornMod.DevilTrigger.JustPressed && shootDemon && currentPower == 1 && demonForm)
            {
                if (!(player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.BloodSeal>()] > 0))
                Projectile.NewProjectile(player.position.X + 10f, player.position.Y + 10f, 0f, 0f, ModContent.ProjectileType<Projectiles.BloodSeal>(), 15, 5f, player.whoAmI);
            }

            if (HalfbornMod.DevilTrigger.JustPressed && shootDemon && currentPower == 2 && demonForm)
            { 
                if (!(player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Void>()] > 0))
                Projectile.NewProjectile(player.position.X + 10f, player.position.Y, 10f, 0f, ModContent.ProjectileType<Projectiles.Void>(), 5, 0f, player.whoAmI, 0f, 0f);
            }

            if (HalfbornMod.DevilTrigger.JustPressed && shootDemon && currentPower == 3 && demonForm) 
            {
                if (!(player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Bubble>()] > 0))
                    Projectile.NewProjectile(player.position.X + 10f, player.position.Y + 10f, 0f, -1f, ModContent.ProjectileType<Projectiles.Bubble>(), 5, 5f, player.whoAmI, 0f, 0f);                
            }

            if (HalfbornMod.DevilTrigger.JustPressed && mageDemon && currentPower == 1 && demonForm)
            {
                int x = (int)(Main.MouseWorld.X / 16); int y = (int)(Main.MouseWorld.Y / 16);
                if (!Main.tile[x, y].active() && !(player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.DemonPortal>()] > 0))
                {
                    Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, -1f, ModContent.ProjectileType<Projectiles.DemonPortal>(), 15, 5f, player.whoAmI, 0f, 0f);
                    player.position = Main.MouseWorld;
                }
            }

            if (HalfbornMod.DevilTrigger.JustPressed && mageDemon && currentPower == 2 && demonForm)
            {
                int myPlayer = Main.myPlayer;
                int num = 15;
                float num2 = 5f;
                num2 = 5f;
                Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
                float x = (float)Main.mouseX + Main.screenPosition.X - vector.X;
                float y = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
                Vector2 value = new Vector2(x, y);
                value.Normalize();
                Vector2 value2 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                value2.Normalize();
                value = value * 4f + value2;
                value.Normalize();
                value *= 17f;
                int num3 = Main.rand.Next(7);
                float num4 = (float)Main.rand.Next(10, 160) * 0.001f;
                if (Main.rand.Next(2) == 0)
                {
                    num4 *= -1f;
                }
                float num5 = (float)Main.rand.Next(10, 160) * 0.001f;
                if (Main.rand.Next(2) == 0)
                {
                    num5 *= -1f;
                }

                {
                    Projectile.NewProjectile(vector.X, vector.Y, value.X, value.Y, ModContent.ProjectileType<Projectiles.DemonTentacle>(), num, num2, myPlayer, num5, num4);
                }
            
            }

            if (HalfbornMod.DevilTrigger.JustPressed && mageDemon && currentPower == 3 && demonForm)
            {
                if (!(player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Lightning1>()] > 0))
                Projectile.NewProjectile(player.Center.X, player.Center.Y - 400f, (float)Main.rand.Next(-3, 3), -6f, ModContent.ProjectileType<Projectiles.Lightning1>(), 15, 2f, player.whoAmI, 0f, 0f);
            }
            if (HalfbornMod.DevilTrigger.JustPressed && summonDemon && currentPower == 1 && demonForm)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (Main.projectile[j].active && Main.projectile[j].type == ModContent.ProjectileType<Projectiles.DemonMinion>() && Main.projectile[j].owner == player.whoAmI)
                    {
                        var positionX = Main.projectile[j].position.X; var positionY = Main.projectile[j].position.Y;
                        Main.projectile[j].Kill();
                        Projectile.NewProjectile(positionX, positionY, 0f, -1f, ModContent.ProjectileType<Projectiles.DemonMinionExplosion>(), 20, 5f, player.whoAmI, 0f, 0f);
                    }
                }
            }
            if (HalfbornMod.DevilTrigger.JustPressed && summonDemon && currentPower == 2 && demonForm)
            {
                int cloneCount = 0;
                if (cloneCount < player.maxMinions)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        player.maxMinions++;
                        if (Main.projectile[j].active && Main.projectile[j].minion && Main.projectile[j].owner == player.whoAmI && Main.projectile[j].Name != "clone")
                        {
                            Projectile minion = Main.projectile[j];
                            int clone = Projectile.NewProjectile(player.position.X, player.position.Y, 0f, -1f, minion.type, 20, 5f, player.whoAmI, 0f, 0f);
                            Main.projectile[clone].Name = "clone";
                            Main.projectile[clone].minionSlots = 0f;
                            Main.projectile[clone].netUpdate = true;
                            cloneCount++;
                        }
                        player.maxMinions--;
                    }
                }
            }
            if (HalfbornMod.DevilTrigger.JustPressed && summonDemon && currentPower == 3 && demonForm)
            {
                if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.DemonMinion>()] < 20)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        player.maxMinions++;
                        int clone = Projectile.NewProjectile(player.position.X, player.position.Y, 0f, -1f, ModContent.ProjectileType<Projectiles.DemonMinion>(), 20, 5f, player.whoAmI, 0f, 0f);
                        player.AddBuff(ModContent.BuffType<Buffs.DemonMinionBuff>(), 3600, true);
                        Main.projectile[clone].Name = "clone";
                        Main.projectile[clone].minionSlots = 0f;
                        player.maxMinions--;
                    }
                }
            }
        }

        public override void UpdateBiomeVisuals()
        {
                player.ManageSpecialBiomeVisuals("Halfborn:WarDemonSky", (demonForm && warDemon));            
                player.ManageSpecialBiomeVisuals("Halfborn:ShootDemonSky", (demonForm && shootDemon));            
                player.ManageSpecialBiomeVisuals("Halfborn:MageDemonSky", (demonForm && mageDemon));                      
                player.ManageSpecialBiomeVisuals("Halfborn:SummonDemonSky", (demonForm && summonDemon));          
        }

        public override void UpdateLifeRegen()
        {
            if (demonForm)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                    player.lifeRegenTime = 0;                
            }
        }

        public override void PostUpdateEquips()
        {
            if (blueGlove || blackGlove || greenGlove || orangeGlove || yellowGlove || redGlove || whiteGlove) anyGlove = true;
            if (blueBelt || blackBelt || greenBelt || orangeBelt || yellowBelt || redBelt || whiteBelt) anyBelt = true;
            if (blueNecklace || blackNecklace || greenNecklace || orangeNecklace || yellowNecklace || redNecklace || whiteNecklace) anyNecklace = true;
            if (blueRing || blackRing || greenRing || orangeRing || yellowRing || redRing || whiteRing) anyRing = true;
            if (blackRing || blackNecklace || blackBelt) anyBlack = true;
            if (blueRing || blueNecklace || blueBelt) anyBlue = true;
            if (greenRing || greenNecklace || greenBelt) anyGreen = true;
            if (orangeRing || orangeNecklace || orangeBelt) anyOrange = true;
            if (redRing || redNecklace || redBelt) anyRed = true;
            if (whiteRing || whiteNecklace || whiteBelt) anyWhite = true;
            if (yellowRing || yellowNecklace || yellowBelt) anyYellow = true;
            if (player.statLife < player.statLifeMax2 / 2 && !demonForm && demonPower > 0 && !player.dead) { demonForm = true; Projectile.NewProjectile(player.position.X, player.position.Y, 0f, -1f, ModContent.ProjectileType<Projectiles.DemonWave>(), 20, 5f, player.whoAmI, 0f, 0f);}

            if (player.FindBuffIndex(ModContent.BuffType<Buffs.Overheat>()) > 0)
            {
                player.ClearBuff(ModContent.BuffType<Buffs.MagicWeapon>());
            }
            if (player.statLife > player.statLifeMax2 / 2)  demonForm = false;     
         
        }       

    }
}