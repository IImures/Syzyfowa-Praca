using System;
using UnityEngine;

namespace Hazards
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Draggable : MonoBehaviour
    {

        private bool _isDraggable = false;
        private bool _isDragging = false;
        private Vector3 _offset;
        private Rigidbody2D _rb;

        public void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void OnMouseDown()
        {
            if (!_isDraggable) return;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _offset = transform.position - new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
            _isDragging = true;
        }

        void OnMouseDrag()
        {
            if (_isDragging)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 targetPosition = new Vector2(mousePosition.x, mousePosition.y) + new Vector2(_offset.x, _offset.y);
                _rb.MovePosition(targetPosition);
            }
        }

        void OnMouseUp()
        {
            _isDragging = false;
        }

        public void EnableDrag()
        {
            _isDraggable = true;
        }

        public void DisableDrag()
        {
            _isDraggable = false;
        }
    }
}
