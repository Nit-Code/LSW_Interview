using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    private Dictionary<CursorName, CursorData> _cursorDataDictionary;

    [SerializeField] SO_CursorList _cursorList;

    protected override void Awake()
    {
        base.Awake();

        CreateCursorDataDictionary();
    }

    public CursorData GetCursorData(CursorName cursorName)
    {
        if (_cursorDataDictionary.TryGetValue(cursorName, out var cursorData))
            return cursorData;
        else
            return null;
    }

    public void ChangeCursor(CursorName cursorName)
    {
        CursorData newCursorData = GetCursorData(cursorName);

        if (newCursorData != null)
            Cursor.SetCursor(newCursorData.cursorImage, Vector2.zero, CursorMode.Auto);
    }

    private void CreateCursorDataDictionary()
    {
        _cursorDataDictionary = new();

        if (_cursorList != null)
            AddCursorDataToDictionary();
    }

    private void AddCursorDataToDictionary()
    {
        foreach(var cursorData in _cursorList.cursorData)
            _cursorDataDictionary.Add(cursorData.name, cursorData);
    }
}
