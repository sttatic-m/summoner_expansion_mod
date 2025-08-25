using SummonerExpansion.Content.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SummonerExpansion.Content.Items.Weapons
{
    public class StarWhip : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.SummonMeleeSpeed;
            
            Item.knockBack = 1;
            Item.rare = ItemRarityID.Green;

            Item.shoot = ModContent.ProjectileType<StarWhipProjectile>();
            Item.shootSpeed = 8;
            Item.noUseGraphic = true;
			Item.damage = 14;
			Item.knockBack = 7f;
			
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.UseSound = SoundID.Item152;
            Item.channel = true; // This is used for the charging functionality. Remove it if your whip shouldn't be chargeable.
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }

        public override bool MeleePrefix()
        {
            return true;
        }
        
    }
}