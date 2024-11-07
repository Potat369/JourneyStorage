using System.Runtime.CompilerServices;
using MagicStorage.Components;
using Terraria.ModLoader;

namespace JourneyStorage.Content;

public class JourneyStorageUnit : StorageComponent
{
    public override TEJourneyStorageUnit GetTileEntity() => ModContent.GetInstance<TEJourneyStorageUnit>();

    public override int ItemType(int frameX, int frameY) => ModContent.ItemType<JourneyStorageUnitItem>();
}