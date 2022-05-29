using UnityEngine;

namespace Scoring
{
    public class GoalGate : MonoBehaviour
    {
        [field: SerializeField] public bool IsPlayerSide { get; private set; }
    }
}