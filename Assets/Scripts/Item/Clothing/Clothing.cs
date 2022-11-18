using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing : Item
{
    private ClothingType _type;
    
    public ClothingType Type { get => _type;}

    public override void Init(string id)
    {
        base.Init(id);

        ItemData itemData = _itemManager.GetItemData(id);

        if (itemData is ClothingData clothingData)
        {
            _type = clothingData.type;
        }
    }
}
