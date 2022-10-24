using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Actor))]
public class ActorInventory : ActorComponent
{
	[CompilerGenerated]
	private sealed class _003CCanAddItem_003Ec__AnonStorey16
	{
		internal InventoryItemEntry oEntry;

		internal bool _003C_003Em__6(InventoryItemEntry o)
		{
			return (o.item == oEntry.item) & (o.quantity + oEntry.quantity <= oEntry.item.maximumQuantity);
		}
	}

	[CompilerGenerated]
	private sealed class _003CCanAddItem_003Ec__AnonStorey17
	{
		internal Item oItem;

		internal int iQuantity;

		internal bool _003C_003Em__7(InventoryItemEntry o)
		{
			return o.item == oItem && o.quantity + iQuantity <= oItem.maximumQuantity;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetItemTotalQuantity_003Ec__AnonStorey18
	{
		internal Item oItem;

		internal bool _003C_003Em__8(InventoryItemEntry o)
		{
			return o.item == oItem;
		}
	}

	[CompilerGenerated]
	private sealed class _003CAddItem_003Ec__AnonStorey19
	{
		internal InventoryItemEntry oEntry;

		internal bool _003C_003Em__A(InventoryItemEntry o)
		{
			return (o.item == oEntry.item) & (o.quantity + oEntry.quantity <= oEntry.item.maximumQuantity);
		}
	}

	[CompilerGenerated]
	private sealed class _003CAddItem_003Ec__AnonStorey1A
	{
		internal Item oItem;

		internal int iQuantity;

		internal bool _003C_003Em__B(InventoryItemEntry o)
		{
			return o.item == oItem && o.quantity + iQuantity <= oItem.maximumQuantity;
		}
	}

	[CompilerGenerated]
	private sealed class _003CRemoveItem_003Ec__AnonStorey1B
	{
		internal Item oItem;

		internal bool _003C_003Em__C(InventoryItemEntry o)
		{
			return o.item == oItem;
		}

		internal bool _003C_003Em__D(InventoryItemEntry o)
		{
			return o.item == oItem && o.quantity == 0;
		}

		internal bool _003C_003Em__E(InventoryItemEntry o)
		{
			return o.item == oItem && o.quantity == 0;
		}
	}

	[CompilerGenerated]
	private sealed class _003CRemoveAllOfItem_003Ec__AnonStorey1C
	{
		internal Item oItem;

		internal bool _003C_003Em__F(InventoryItemEntry o)
		{
			return o.item == oItem;
		}

		internal bool _003C_003Em__10(InventoryItemEntry o)
		{
			return o.item == oItem;
		}
	}

	[SerializeField]
	protected List<InventoryItemEntry> _items = new List<InventoryItemEntry>();

	[SerializeField]
	protected bool _isFixedSize;

	[SerializeField]
	protected int _maximumEntries = -1;

	[CompilerGenerated]
	private static Predicate<InventoryItemEntry> _003C_003Ef__am_0024cache3;

	[CompilerGenerated]
	private static Predicate<InventoryItemEntry> _003C_003Ef__am_0024cache4;

	public List<InventoryItemEntry> items
	{
		get
		{
			return _items;
		}
	}

	public bool isFixedSize
	{
		get
		{
			return _isFixedSize;
		}
	}

	public int maximumEntries
	{
		get
		{
			return _maximumEntries;
		}
	}

	public bool CanAddItem(InventoryItemEntry oEntry)
	{
		_003CCanAddItem_003Ec__AnonStorey16 _003CCanAddItem_003Ec__AnonStorey = new _003CCanAddItem_003Ec__AnonStorey16();
		_003CCanAddItem_003Ec__AnonStorey.oEntry = oEntry;
		if (_003CCanAddItem_003Ec__AnonStorey.oEntry.item == null)
		{
			return false;
		}
		InventoryItemEntry inventoryItemEntry = items.Find(_003CCanAddItem_003Ec__AnonStorey._003C_003Em__6);
		if (inventoryItemEntry != null)
		{
			return true;
		}
		if ((maximumEntries == -1) | (GetValidEntryCount() + 1 <= maximumEntries))
		{
			return true;
		}
		return false;
	}

	public bool CanAddItem(Item oItem, int iQuantity)
	{
		_003CCanAddItem_003Ec__AnonStorey17 _003CCanAddItem_003Ec__AnonStorey = new _003CCanAddItem_003Ec__AnonStorey17();
		_003CCanAddItem_003Ec__AnonStorey.oItem = oItem;
		_003CCanAddItem_003Ec__AnonStorey.iQuantity = iQuantity;
		if (_003CCanAddItem_003Ec__AnonStorey.oItem == null)
		{
			return false;
		}
		InventoryItemEntry inventoryItemEntry = items.Find(_003CCanAddItem_003Ec__AnonStorey._003C_003Em__7);
		if (inventoryItemEntry != null)
		{
			return true;
		}
		if ((maximumEntries == -1) | (GetValidEntryCount() + 1 <= maximumEntries))
		{
			return true;
		}
		return false;
	}

	public int GetItemTotalQuantity(Item oItem)
	{
		_003CGetItemTotalQuantity_003Ec__AnonStorey18 _003CGetItemTotalQuantity_003Ec__AnonStorey = new _003CGetItemTotalQuantity_003Ec__AnonStorey18();
		_003CGetItemTotalQuantity_003Ec__AnonStorey.oItem = oItem;
		if (_003CGetItemTotalQuantity_003Ec__AnonStorey.oItem == null)
		{
			return -1;
		}
		int num = 0;
		List<InventoryItemEntry> list = items.FindAll(_003CGetItemTotalQuantity_003Ec__AnonStorey._003C_003Em__8);
		for (int i = 0; i < list.Count; i++)
		{
			num += list[i].quantity;
		}
		return num;
	}

	public int GetValidEntryCount()
	{
		List<InventoryItemEntry> list = items;
		if (_003C_003Ef__am_0024cache3 == null)
		{
			_003C_003Ef__am_0024cache3 = _003CGetValidEntryCount_003Em__9;
		}
		List<InventoryItemEntry> list2 = list.FindAll(_003C_003Ef__am_0024cache3);
		return list2.Count;
	}

	public void AddItem(InventoryItemEntry oEntry)
	{
		_003CAddItem_003Ec__AnonStorey19 _003CAddItem_003Ec__AnonStorey = new _003CAddItem_003Ec__AnonStorey19();
		_003CAddItem_003Ec__AnonStorey.oEntry = oEntry;
		if (!(_003CAddItem_003Ec__AnonStorey.oEntry.item == null))
		{
			InventoryItemEntry inventoryItemEntry = items.Find(_003CAddItem_003Ec__AnonStorey._003C_003Em__A);
			if (inventoryItemEntry != null)
			{
				inventoryItemEntry.quantity += _003CAddItem_003Ec__AnonStorey.oEntry.quantity;
				_003CAddItem_003Ec__AnonStorey.oEntry.OnAddedQuantity(_003CAddItem_003Ec__AnonStorey.oEntry.quantity);
			}
			else if ((maximumEntries == -1) | (GetValidEntryCount() + 1 <= maximumEntries))
			{
				InventoryItemEntry inventoryItemEntry2 = new InventoryItemEntry();
				inventoryItemEntry2.Initialize(this);
				inventoryItemEntry2.item = _003CAddItem_003Ec__AnonStorey.oEntry.item;
				inventoryItemEntry2.quantity = _003CAddItem_003Ec__AnonStorey.oEntry.quantity;
				inventoryItemEntry2.quality = _003CAddItem_003Ec__AnonStorey.oEntry.quality;
				items.Add(inventoryItemEntry2);
				inventoryItemEntry2.OnAdded();
			}
		}
	}

	public void AddItem(Item oItem, int iQuantity)
	{
		_003CAddItem_003Ec__AnonStorey1A _003CAddItem_003Ec__AnonStorey1A = new _003CAddItem_003Ec__AnonStorey1A();
		_003CAddItem_003Ec__AnonStorey1A.oItem = oItem;
		_003CAddItem_003Ec__AnonStorey1A.iQuantity = iQuantity;
		if (!(_003CAddItem_003Ec__AnonStorey1A.oItem == null))
		{
			InventoryItemEntry inventoryItemEntry = items.Find(_003CAddItem_003Ec__AnonStorey1A._003C_003Em__B);
			if (inventoryItemEntry != null)
			{
				inventoryItemEntry.quantity += _003CAddItem_003Ec__AnonStorey1A.iQuantity;
				inventoryItemEntry.OnAddedQuantity(_003CAddItem_003Ec__AnonStorey1A.iQuantity);
			}
			else if (((maximumEntries == -1) | (GetValidEntryCount() + 1 <= maximumEntries)) && isFixedSize)
			{
				InventoryItemEntry inventoryItemEntry2 = new InventoryItemEntry();
				inventoryItemEntry2.Initialize(this);
				inventoryItemEntry2.item = _003CAddItem_003Ec__AnonStorey1A.oItem;
				inventoryItemEntry2.quantity = _003CAddItem_003Ec__AnonStorey1A.iQuantity;
				items.Add(inventoryItemEntry2);
				inventoryItemEntry2.OnAdded();
			}
		}
	}

	public void RemoveItem(Item oItem, int iQuantity)
	{
		_003CRemoveItem_003Ec__AnonStorey1B _003CRemoveItem_003Ec__AnonStorey1B = new _003CRemoveItem_003Ec__AnonStorey1B();
		_003CRemoveItem_003Ec__AnonStorey1B.oItem = oItem;
		if (_003CRemoveItem_003Ec__AnonStorey1B.oItem == null)
		{
			return;
		}
		List<InventoryItemEntry> list = items.FindAll(_003CRemoveItem_003Ec__AnonStorey1B._003C_003Em__C);
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			int num2 = Mathf.Clamp(list[i].quantity, 0, iQuantity - num);
			list[i].OnRemovedQuantity(num2);
			list[i].quantity -= num2;
			num += num2;
			if (num >= iQuantity)
			{
				break;
			}
		}
		list = items.FindAll(_003CRemoveItem_003Ec__AnonStorey1B._003C_003Em__D);
		for (int j = 0; j < list.Count; j++)
		{
			list[j].OnRemoved();
		}
		items.RemoveAll(_003CRemoveItem_003Ec__AnonStorey1B._003C_003Em__E);
	}

	public void RemoveAllOfItem(Item oItem)
	{
		_003CRemoveAllOfItem_003Ec__AnonStorey1C _003CRemoveAllOfItem_003Ec__AnonStorey1C = new _003CRemoveAllOfItem_003Ec__AnonStorey1C();
		_003CRemoveAllOfItem_003Ec__AnonStorey1C.oItem = oItem;
		List<InventoryItemEntry> list = items.FindAll(_003CRemoveAllOfItem_003Ec__AnonStorey1C._003C_003Em__F);
		foreach (InventoryItemEntry item in items)
		{
			item.OnRemoved();
		}
		items.RemoveAll(_003CRemoveAllOfItem_003Ec__AnonStorey1C._003C_003Em__10);
	}

	public void RemoveNullEntries()
	{
		if (!isFixedSize)
		{
			List<InventoryItemEntry> list = items;
			if (_003C_003Ef__am_0024cache4 == null)
			{
				_003C_003Ef__am_0024cache4 = _003CRemoveNullEntries_003Em__11;
			}
			list.RemoveAll(_003C_003Ef__am_0024cache4);
		}
	}

	private void Awake()
	{
		for (int i = 0; i < items.Count; i++)
		{
			items[i].Initialize(this);
		}
	}

	[CompilerGenerated]
	private static bool _003CGetValidEntryCount_003Em__9(InventoryItemEntry o)
	{
		return o.item != null;
	}

	[CompilerGenerated]
	private static bool _003CRemoveNullEntries_003Em__11(InventoryItemEntry o)
	{
		return o.item == null;
	}
}
