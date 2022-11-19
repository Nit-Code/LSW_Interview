using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "so_CursorList", menuName = "Scriptable Objects/Cursors/Cursor List")]
public class SO_CursorList : ScriptableObject
{
    [SerializeField]
    public List<CursorData> cursorData;
}
