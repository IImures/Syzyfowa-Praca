using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Player Config", fileName = "New Player")]
    public class PlayerConfig : ScriptableObject
    {
        //Player movement
        public float speed = 10f;
        public float acceleration = 10f;
        public float deceleration = 10f;
        public float knockBackFreezeTime = 0.2f;
    }
}
