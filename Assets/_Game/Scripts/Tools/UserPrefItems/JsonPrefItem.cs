using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Tools.UserPrefItems
{
    [Serializable]
    public class JsonPrefItem<T>
    {
        [SerializeField] private StrPlayerPrefItem stringItem;

        public JsonPrefItem(StrPlayerPrefItem stringItem)
        {
            this.stringItem = stringItem;
        }

        public bool TryGetValue(out T result)
        {
            try
            {
                result = JsonConvert.DeserializeObject<T>(stringItem.Value);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                result = default;
                return false;
            }
        }

        public bool TrySetValue(T value)
        {
            try
            {
                stringItem.Value = JsonConvert.SerializeObject(value);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }

        public bool HasKey() => stringItem.HasKey();
    }
}