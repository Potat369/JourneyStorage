using System;
using MagicStorage.Components;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JourneyStorage.Content;

public class TEJourneyStorageUnit : TEAbstractStorageUnit
{
	private static Item[] _items;
	private static List<int> _sacrifices = new(ItemLoader.ItemCount);
	
	public override bool IsFull => true;

	public override bool ValidTile(in Tile tile) => tile.TileType == ModContent.TileType<JourneyStorageUnit>() && tile is { TileFrameX: 0, TileFrameY: 0 };

	public override bool HasSpaceInStackFor(Item check) => _items[check.type] != null;

	public override bool HasItem(Item check, bool ignorePrefix = false) => !Inactive;

	public override IEnumerable<Item> GetItems()
	{
		if (_items == null)
			_items = new Item[ItemLoader.ItemCount];
		_sacrifices.Clear();
		Main.LocalPlayerCreativeTracker.ItemSacrifices.FillListOfItemsThatCanBeObtainedInfinitely(_sacrifices);
		foreach (var id in _sacrifices)
		{
			var item = _items[id];

			if (item is null)
				item = _items[id] = new Item(id);
			else if (item.type != id || item.IsAir)
				item.SetDefaults(id);
			
			item.stack = item.maxStack;
			yield return item;
		}
	}

	public override void DepositItem(Item toDeposit)
	{
		toDeposit.stack = 0;
	}

	public override Item TryWithdraw(Item lookFor, bool locked = false, bool keepOneIfFavorite = false)
	{
		return _items[lookFor.type] != null ? lookFor.Clone() : lookFor;
	}
}
