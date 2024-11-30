using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragReporter : MonoBehaviour
{
    private bool _isDragging=false;

    private Vector2 _startPos;

    private Vector2 _endPos;

    private Vector2 dragVector;
    
    private Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        _isDragging = false;
        dragVector = _endPos - _startPos;
    }

    private void OnMouseDrag()
    {
        _endPos = GetMousePosition();
    }

    private void OnMouseDown()
    {
        _isDragging = true;
        _startPos = GetMousePosition();
    }

    public Vector2 ConsumeDrag()
    {
        var tmp = dragVector;
        dragVector = new Vector2(0,0);
        return tmp;
    }

    public bool DragPerformed()
    {
        return dragVector.x != 0 || dragVector.y != 0;
    }
}
