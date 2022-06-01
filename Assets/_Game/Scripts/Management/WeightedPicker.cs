using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Management
{
    [Serializable]
    public class ProviderOption<T>
    {
        [field: SerializeField] public T Item { get; private set; }
        [field: SerializeField] public float Weight { get; private set; } = 1f;
    }
    
    [Serializable]
    public class WeightedPicker<T>
    {
        [SerializeField] private ProviderOption<T>[] options;

        public T Pick()
        {
            if(!options.Any())
                throw new Exception("No options");
            var option = WeightedPickOrDefault(options, o => o.Weight);
            return option.Item;
        }
        
        // we could cache and make O(n*log2(n)), but its not so important for now to care about
        public static T WeightedPickOrDefault<T>(IList<T> list, Func<T, float> weightFunc)
        {
            if (!list.Any())
                return default;

            var weights = list.Select(weightFunc).ToArray();
            var totalWeight = weights.Sum();
            var pick = Random.value * totalWeight;
            var min = 0f;
            for (var i = 0; i < weights.Count(); i++)
            {
                min += weights[i];
                if (min >= pick)
                    return list[i];
            }
            return default;
        }
    }
}