using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScripts : MonoBehaviour
{
    public Texture2D cursorTexture;

    private CursorMode mode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, mode);
    }
}
