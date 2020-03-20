using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HalfbornMod
{
    public class HalfbornProjectile : GlobalProjectile
    {
        Player player = Main.player[Main.myPlayer];
        public override bool InstancePerEntity
        {
            get { return true; }
        }
        public override void AI(Projectile projectile)
        {
            if (projectile.active && projectile.minion && projectile.owner == player.whoAmI && projectile.Name == "clone")
            {
                projectile.ai[0]++;
                if (projectile.ai[0] > 350) projectile.Kill();
            }
        }
        public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {

                if (projectile.active && projectile.minion && projectile.owner == player.whoAmI && projectile.Name == "clone")
                {

                    return new Color(0f, 0.5f, 1f, 0.5f);

                }
            
            return null;
        }        
    }
}