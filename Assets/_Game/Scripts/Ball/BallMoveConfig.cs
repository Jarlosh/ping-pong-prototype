using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "SO/BallMoveConfig", fileName = "BallMoveConfig", order = 0)]
    public class BallMoveConfig : ScriptableObject
    {
        [SerializeField] private float moveSpeed = 10;
        [SerializeField] private float size = 1;
        
        public float MoveSpeed => moveSpeed;
        public float Size => size;
    }
}