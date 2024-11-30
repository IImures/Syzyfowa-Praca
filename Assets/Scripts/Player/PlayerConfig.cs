using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Player Config", fileName = "New Player")]
    public class PlayerConfig : ScriptableObject
    {
        //Player movement
        public float speed = 4f;
        public float acceleration = 4f;
        public float deceleration = 4f;
    }
}
