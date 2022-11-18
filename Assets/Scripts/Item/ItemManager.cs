using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Dictionary<string, ItemData> _itemDataDictionary;

    // Data scriptable objects

    // Clothing
    [SerializeField] private SO_ClothingList_Torso _torsoClothingDataSO;
    [SerializeField] private SO_ClothingList_Legs _legsClothingDataSO;

    private void Awake()
    {
        CreateItemDataDictionary();
    }

    public ItemData GetItemData(string id)
    {
        if (_itemDataDictionary.TryGetValue(id, out var itemData))
            return itemData;
        else
            return null;
    }

    private void CreateItemDataDictionary()
    {
        _itemDataDictionary = new Dictionary<string, ItemData>();

        // Clothing
        if (_torsoClothingDataSO != null)
            AddTorsoClothingDataToDictionary();
        if (_legsClothingDataSO != null)
            AddLegsClothingDataToDictionary();    
    }

    private void AddTorsoClothingDataToDictionary()
    {
        foreach (ClothingData_Torso torsoClothingData in _torsoClothingDataSO.torsoClothingData)
            _itemDataDictionary.Add(torsoClothingData.id, torsoClothingData);
    }

    private void AddLegsClothingDataToDictionary()
    {
        foreach (ClothingData_Legs legsClothingData in _legsClothingDataSO.legsClothingData)
            _itemDataDictionary.Add(legsClothingData.id, legsClothingData);
    }
}
