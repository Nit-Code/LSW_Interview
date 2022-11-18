using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "so_ClothingList_Torso", menuName = "Scriptable Objects/Clothing/Torso Clothing List")]

public class SO_ClothingList_Torso : ScriptableObject
{
    [SerializeField]
    public List<ClothingData_Torso> torsoClothingData;
}
