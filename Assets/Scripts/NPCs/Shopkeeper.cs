using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Shopkeeper : MonoBehaviour
{
    public void OnMouseEnter()
    {
        CursorManager.Instance.ChangeCursor(CursorName.Interact_Talk);
    }

    public void OnMouseExit()
    {
        CursorManager.Instance.ChangeCursor(CursorName.Default);
    }

    public void OnMouseDown()
    {
        InteractWithShopkeeper();
    }

    protected abstract void InteractWithShopkeeper();
}
