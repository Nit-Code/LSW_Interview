using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_InventoryBar : MonoBehaviour
{
    [SerializeField] private List<UI_InventorySlot> _inventorySlots;

    private void Awake()
    { 
        GetInventorySlots();
    }

    private void OnEnable()
    {
        EventHandler.PlayerInventoryUpdatedEvent += UpdateInventoryBar;
    }

    private void OnDisable()
    {
        EventHandler.PlayerInventoryUpdatedEvent -= UpdateInventoryBar;
    }

    private void GetInventorySlots()
    {
        _inventorySlots = new();

        _inventorySlots = GetComponentsInChildren<UI_InventorySlot>().ToList();
    }

    private void UpdateInventoryBar(List<InventoryItem> inventoryList)
    {
        ClearInventorySlots();

        if(_inventorySlots.Count> 0 && inventoryList.Count > 0) // We loop through both the inventory bar slots and the player's inventory
        {
            for(int i = 0; i < inventoryList.Count; i++) // We populate each inventory slot
            {
                if (i < inventoryList.Count)
                {
                    InventoryItem item = inventoryList[i];
                    ItemData itemData = ItemManager.Instance.GetItemData(item.itemId);

                    if (itemData != null)
                    {
                        _inventorySlots[i].SetSlotItem(itemData, item.itemQuantity);
                    }
                }
                else
                  break;
            }
        }
    }

    private void ClearInventorySlots()
    {
        if(_inventorySlots.Count > 0)
        {
            for(int i = 0; i < _inventorySlots.Count; i++)
            {
                _inventorySlots[i].ClearSlot();
            }
        }
    }
}
