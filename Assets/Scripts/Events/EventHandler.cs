using System;
using System.Collections.Generic;

public static class EventHandler
{
    #region SceneEvents

    // (The code in this region is from a previous project I worked on)

    public static event Action OurBeforeSceneUnloadEvent;

    public static void CallBeforeSceneUnloadEvent()
    {
        if (OurBeforeSceneUnloadEvent != null)
        {
            OurBeforeSceneUnloadEvent();
        }
    }

    public static event Action OurAfterSceneUnloadEvent;

    public static void CallAfterSceneUnloadEvent()
    {
        if (OurAfterSceneUnloadEvent != null)
        {
            OurAfterSceneUnloadEvent();
        }
    }

    public static event Action OurBeforeSceneLoadEvent;

    public static void CallBeforeSceneLoadEvent()
    {
        if (OurBeforeSceneLoadEvent != null)
        {
            OurBeforeSceneLoadEvent();
        }
    }

    public static event Action OurAfterSceneLoadEvent;

    public static void CallAfterSceneLoadEvent()
    {
        if (OurAfterSceneLoadEvent != null)
        {
            OurAfterSceneLoadEvent();
        }
    }
    #endregion

    #region PlayerInventoryEvents

    public static event Action<List<InventoryItem>> PlayerInventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(List<InventoryItem> inventoryList)
    {
        if (PlayerInventoryUpdatedEvent != null)
            PlayerInventoryUpdatedEvent(inventoryList);
    }

    #endregion

    #region ShopInventoryEvents

    public static event Action<List<InventoryItem>> ShopInventoryUpdatedEvent;

    public static void CallShopInventoryUpdatedEvent(List<InventoryItem> inventoryList)
    {
        if (ShopInventoryUpdatedEvent != null)
            ShopInventoryUpdatedEvent(inventoryList);
    }

    #endregion
}