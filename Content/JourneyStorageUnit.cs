using System.Runtime.CompilerServices;
using MagicStorage.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace JourneyStorage.Content;

public class JourneyStorageUnit : StorageComponent
{
    public override TEJourneyStorageUnit GetTileEntity() => ModContent.GetInstance<TEJourneyStorageUnit>();

    public override int ItemType(int frameX, int frameY) => ModContent.ItemType<JourneyStorageUnitItem>();
    
    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
    {
        Tile tile = Main.tile[i, j];
        Vector2 position = (Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange)) + 16f * new Vector2(i, j) - Main.screenPosition;
        Rectangle rectangle = new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, 16);
        Color color = Color.Lerp(Color.White, Lighting.GetColor(i, j, Color.White), 0.5f);
        spriteBatch.Draw(Mod.Assets.Request<Texture2D>("Content/JourneyStorageUnit_Glow").Value, position, rectangle, color);
    }
}