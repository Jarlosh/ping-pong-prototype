using UnityEngine;

namespace Tools
{
    public static class JRandom
    {
        public static bool CoinFlip() => Random.value > 0.5f;
    }
}