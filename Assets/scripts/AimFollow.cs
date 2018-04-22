﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimFollow : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    private void OnDestroy()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}