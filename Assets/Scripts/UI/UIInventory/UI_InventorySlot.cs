using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _inventorySlotHighlight;
    [SerializeField] private Image _inventorySlotImage;
    [SerializeField] private TextMeshProUGUI _itemQuantityText;
    [SerializeField] private int _slotNumber;

    private ItemData _itemData;
    private int _itemQuantity;

    public void ClearSlot()
    {
        _inventorySlotImage.enabled = false;
        _itemQuantityText.enabled = false;

        _itemData = null;
        _itemQuantity = 0;
    }

    public void SetSlotItem(ItemData itemData,int quantity)
    {
        _inventorySlotImage.sprite = itemData.sprite;     
        _itemQuantityText.text = quantity.ToString();

        _inventorySlotImage.enabled = true;
        _itemQuantityText.enabled = true;

        _itemData = itemData;
        _itemQuantity = quantity;
    }
}
