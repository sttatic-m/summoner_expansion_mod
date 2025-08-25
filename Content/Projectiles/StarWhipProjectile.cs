using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonerExpansion.Content.Projectiles
{
    public class StarWhipProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.IsAWhip[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DefaultToWhip();
            Projectile.light = 0.6f;
            Projectile.WhipSettings.RangeMultiplier *= 0.45f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
            Projectile.damage = (int)(Projectile.damage * 0.7f);
            Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), new Vector2(target.position.X, target.position.Y - 250.0f), new Vector2(0.0f, 20.0f), 9, 1, Projectile.knockBack, Main.myPlayer, 5, 1);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            List<Vector2> list = new List<Vector2>();
            Projectile.FillWhipControlPoints(Projectile, list);
            Main.DrawWhip_WhipBland(Projectile, list);

            return false;
        }
        

    }
}