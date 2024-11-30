using Unity.VisualScripting;
using UnityEngine;

namespace Hazards
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class FallingRockController : MonoBehaviour
    {

        private FallingRock _fallingRock;
        private BoxCollider2D _bc;
        
        void Awake()
        {
            _fallingRock = transform.GetChild(0).GetComponent<FallingRock>();
            _bc = GetComponent<BoxCollider2D>();
        }

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Player"))
            {
                
                _fallingRock.Fall();
                _bc.enabled = false;
            }
        }

    }
}
