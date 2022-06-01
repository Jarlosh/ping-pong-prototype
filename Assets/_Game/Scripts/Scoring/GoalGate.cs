using UnityEngine;

namespace Meta.Scoring
{
    public class GoalGate : MonoBehaviour
    {
        [field: SerializeField] public bool IsPlayerSide { get; private set; }
    }
}