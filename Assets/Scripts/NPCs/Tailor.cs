using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tailor : Shopkeeper
{
    protected override void InteractWithShopkeeper()
    {
        Debug.Log("Welcome to my shop!");
    }
}
