using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public static class IEnumerableExtension {
    public static IEnumerable<T> InfinityRepeat<T>(this IEnumerable<T> list) {
        for (;;)
            foreach (var t in list)
                yield return t;
    }
}
