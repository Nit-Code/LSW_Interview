using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "so_ClothingList_Legs", menuName = "Scriptable Objects/Clothing/Legs Clothing List")]

public class SO_ClothingList_Legs : ScriptableObject
{
    [SerializeField]
    public List<ClothingData_Legs> legsClothingData;
}
