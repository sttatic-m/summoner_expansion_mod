using SummonerExpansion.Content.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonerExpansion.Common.System
{
    public class ChestItemWorldGen : ModSystem
    {
        public override void PostWorldGen()
        {
            int[] itemsToPlaceInSkyChests = [ModContent.ItemType<StarWhip>()];
            int itemsToPlaceInSkyChestsChoice = 0;
            int itemsPlaced = 0;
            int maxItems = 1;

            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest == null) { continue; }
                Tile chestTile = Main.tile[chest.x, chest.y];
                if (chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 14 * 36)
                {
                    if (WorldGen.genRand.NextBool(3)) continue;

                    for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(WorldGen.genRand.Next(itemsToPlaceInSkyChests));
                            itemsToPlaceInSkyChestsChoice = (itemsToPlaceInSkyChestsChoice + 1) % itemsToPlaceInSkyChests.Length;
                            itemsPlaced++;
                            break;
                        }
                    }
                }

                if (itemsPlaced >= maxItems)
                {
                    break;
                }
            }
        }
    }
}