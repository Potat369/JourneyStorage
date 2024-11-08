using MagicStorage.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JourneyStorage.Content;

public class JourneyStorageUnitItem : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 26;
        Item.height = 26;
        Item.maxStack = 99;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.consumable = true;
        Item.rare = ItemRarityID.White;
        Item.createTile = ModContent.TileType<JourneyStorageUnit>();
    }
    
    public override void AddRecipes()
    {
        var recipe = CreateRecipe();
        recipe.AddIngredient<StorageComponent>();
        recipe.AddRecipeGroup("MagicStorage:AnyDiamond", 1);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}