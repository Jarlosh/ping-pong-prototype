using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Tools
{
    public static class LinqExtensions
    {
        public static T PickOrDefault<T>(this IList<T> list)
        {
            if (!list.Any())
                return default;
            return list[Random.Range(0, list.Count)];
        }
    }
}