using SummonerExpansion.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonerExpansion.Content.Projectiles.Minions
{
    public class HarpyMinion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.minionSlots = 1f;
            Projectile.penetrate = -1;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<HarpyMinionBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<HarpyMinionBuff>()))
            {
                Projectile.timeLeft = 2;
            }
        }
    }
}