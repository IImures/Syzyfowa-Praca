using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOnDrag : MonoBehaviour
{
    [SerializeField] protected float desiredVerticalDirection=-1;
    [SerializeField] protected float desiredHorizontalDirection=-1;
    protected DragReporter _dragReporter;
    void Awake()
    {
        _dragReporter = GetComponent<DragReporter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_dragReporter.DragPerformed())
        {
            var drag = _dragReporter.ConsumeDrag();
            if (DragDirectionOk(drag))
            {
                PerformAction(drag);
            }
        }
    }

    private bool DragDirectionOk(Vector2 drag)
    {
        bool verticalDirOk = desiredVerticalDirection >= 0
            ? drag.y >= desiredVerticalDirection
            :drag.y < desiredVerticalDirection;
        bool horizontalDirOk = desiredHorizontalDirection >= 0
            ? drag.x >= desiredHorizontalDirection
            :drag.x < desiredHorizontalDirection;
        return verticalDirOk && horizontalDirOk;
    }

    protected virtual void PerformAction(Vector2 drag)
    {
        
    }
    
}
