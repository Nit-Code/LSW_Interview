using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : Singleton<PlayerInventoryManager>
{
    public List<InventoryItem> inventoryList;

    protected override void Awake()
    {
        base.Awake();
    }

    public void AddItem(Item item)
    {
        string itemId = item.Id;

        int itemPosition = FindItemInInventory(itemId);

        AddItemAtInventoryPosition(itemId, itemPosition);
    }

    private void AddItemAtInventoryPosition(string itemId, int itemPosition)
    {
        InventoryItem inventoryItem = new InventoryItem();
        inventoryItem.itemId = itemId;

        if (itemPosition == -1) // Item was not found in the inventory
        { 
            inventoryItem.itemQuantity = 1;
            inventoryList.Add(inventoryItem);
        }
        else
        {
            int quantity = inventoryList[itemPosition].itemQuantity + 1;
            inventoryItem.itemQuantity = quantity;
            inventoryList[itemPosition] = inventoryItem;
        }
    }

    private int FindItemInInventory(string itemId)
    {
        for(int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].itemId == itemId)
                return i;
        }

        return -1;
    }
}
