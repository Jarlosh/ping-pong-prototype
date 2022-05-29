using System;
using System.Collections;
using UnityEngine;

namespace Tools
{
    public class CoroutineHelpers
    {
        public static void DoAfter(MonoBehaviour mb, float delay, Action action)
        {
            mb.StartCoroutine(Coroutine());

            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(delay);
                action();
            } 
        }
    }
}