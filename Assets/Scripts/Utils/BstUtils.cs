using System;
using System.Collections.Generic;

public static class BstUtils
{
    /// <summary>
    /// 只能升序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sources"></param>
    /// <param name="target"></param>
    public static bool BinarySearch<T>(List<T> sources, T target, System.Func<T, T, int> compare, out int index)
    {
        return __BinarySearch(sources, compare, target, 0, sources.Count - 1, out index);
    }

    /// <summary>
    /// 只能升序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sources"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static bool BinaryAdd<T>(List<T> sources, T target, System.Func<T, T, int> compare)
    {
        if (__BinarySearch(sources, compare, target, 0, sources.Count - 1, out var index))
        {
            sources[index] = target;
        }
        else
        {
            sources.Insert(index, target);
        }
        return true;
    }

    public static bool BinarySearch2<T>(List<T> sources, System.Func<T, int> compare, out int index)
    {
        return __BinarySearch(sources, compare, 0, sources.Count - 1, out index);
    }

    public static bool BinaryAdd2<T>(List<T> sources, System.Func<T, int> compare, out int index)
    {
        return __BinarySearch(sources, compare, 0, sources.Count - 1, out index);
    }

    private static bool __BinarySearch<T>(List<T> sources, System.Func<T, int> compare, int start, int end, out int index)
    {
        while (start <= end)
        {
            var medIndex = start + (end - start) / 2;
            var med = sources[medIndex];
            var compValue = compare.Invoke(med);
            if (compValue < 0)
            {
                end = medIndex - 1;
            }
            else if (compValue > 0)
            {
                start = medIndex + 1;
            }
            else
            {
                index = medIndex;
                return true;
            }
        }
        index = start;
        return false;
    }

    private static bool __BinarySearch<T>(List<T> sources, IComparer<T> compare, T target, int start, int end, out int index)
    {
        while (start <= end)
        {
            var medIndex = start + (end - start) / 2;
            var med = sources[medIndex];
            var compValue = compare.Compare(target, med);
            if (compValue < 0)
            {
                end = medIndex - 1;
            }
            else if (compValue > 0)
            {
                start = medIndex + 1;
            }
            else
            {
                index = medIndex;
                return true;
            }

        }
        index = start;
        return false;
    }

    private static bool __BinarySearch<T>(List<T> sources, System.Func<T, T, int> compare, T target, int start, int end, out int index)
    {
        while (start <= end)
        {
            var medIndex = start + (end - start) / 2;
            var med = sources[medIndex];
            var compValue = compare.Invoke(target, med);
            if (compValue < 0)
            {
                end = medIndex - 1;
            }
            else if (compValue > 0)
            {
                start = medIndex + 1;
            }
            else
            {
                index = medIndex;
                return true;
            }

        }
        index = start;
        return false;
    }
}
