using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestListOrDict
{
    public class TestData { 
        public int ident;
        public int value;
    }
    public List<TestData> list5 = new List<TestData>();
    public List<TestData> list10 = new List<TestData>();
    public List<TestData> list100 = new List<TestData>();
    public List<TestData> list1000 = new List<TestData>();

    public Dictionary<int,TestData> dict5 = new Dictionary<int, TestData>();
    public Dictionary<int,TestData> dict10 = new Dictionary<int, TestData>();
    public Dictionary<int, TestData> dict100 = new Dictionary<int, TestData>();
    public Dictionary<int, TestData> dict1000 = new Dictionary<int, TestData>();

    public List<int> query5 = new List<int>();
    public List<int> query10 = new List<int>();
    public List<int> query100 = new List<int>();
    public List<int> query1000 = new List<int>();

    public void Init()
    {
        for (int i = 0; i < 5; i++)
        {
            var tmpData = new TestData()
            {
                ident = i,
                value = UnityEngine.Random.Range(0, 10),
            };
            list5.Add(tmpData);
            dict5.Add(i, tmpData);
        }

        for (int i = 0; i < 10; i++)
        {
            var tmpData = new TestData()
            {
                ident = i,
                value  = UnityEngine.Random.Range(0,10),
            };
            list10.Add(tmpData);
            dict10.Add(i, tmpData);
        }

        for (int i = 0; i < 100; i++)
        {
            var tmpData = new TestData()
            {
                ident = i,
                value = UnityEngine.Random.Range(0, 10),
            };
            list100.Add(tmpData);
            dict100.Add(i, tmpData);
        }

        for (int i = 0; i < 1000; i++)
        {
            var tmpData = new TestData()
            {
                ident = i,
                value = UnityEngine.Random.Range(0, 10),
            };
            list1000.Add(tmpData);
            dict1000.Add(i, tmpData);
        }

        for (int i = 0; i < 1000; i++)
        {
            query5.Add(UnityEngine.Random.Range(0, 5));
            query10.Add(UnityEngine.Random.Range(0, 10));
            query100.Add(UnityEngine.Random.Range(0, 100));
            query1000.Add(UnityEngine.Random.Range(0, 1000));
        }
    }

    // Update is called once per frame
    public void Test()
    {
        {
            UnityEngine.Profiling.Profiler.BeginSample(nameof(list5));
            var sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                var nCount = list5.Count;
                for (int j = 0; j < nCount; j++)
                {
                    if (list5[j].ident == query5[i])
                    {
                        sum += list5[j].value;
                        break;
                    }
                }
            }
            UnityEngine.Profiling.Profiler.EndSample();
        }

        {
            UnityEngine.Profiling.Profiler.BeginSample(nameof(dict5));
            var sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                dict5.TryGetValue(query5[i], out var t);
                sum += t != null ? t.value : 0;
            }
            UnityEngine.Profiling.Profiler.EndSample();
        }

        {
            UnityEngine.Profiling.Profiler.BeginSample(nameof(list10));
            var sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                var nCount = list10.Count;
                for (int j = 0; j < nCount; j++)
                {
                    if (list10[j].ident == query10[i])
                    {
                        sum += list10[j].value;
                        break;
                    }
                }
            }
            UnityEngine.Profiling.Profiler.EndSample();
        }

        {
            UnityEngine.Profiling.Profiler.BeginSample(nameof(dict10));
            var sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                dict10.TryGetValue(query10[i], out var t);
                sum += t != null ? t.value : 0;
            }
            UnityEngine.Profiling.Profiler.EndSample();
        }

        {
            UnityEngine.Profiling.Profiler.BeginSample(nameof(list100));
            var sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                var nCount = list100.Count;
                for (int j = 0; j < nCount; j++)
                {
                    if (list100[j].ident == query100[i])
                    {
                        sum += list100[j].value;
                        break;
                    }
                }
            }
            UnityEngine.Profiling.Profiler.EndSample();
        }

        {
            UnityEngine.Profiling.Profiler.BeginSample(nameof(dict100));
            var sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                dict100.TryGetValue(query100[i], out var t);
                sum += t != null ? t.value : 0;
            }
            UnityEngine.Profiling.Profiler.EndSample();
        }

        {
            UnityEngine.Profiling.Profiler.BeginSample(nameof(list1000));
            var sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                var nCount = list1000.Count;
                for (int j = 0; j < nCount; j++)
                {
                    if (list1000[j].ident == query1000[i])
                    {
                        sum += list1000[j].value;
                        break;
                    }
                }
            }
            UnityEngine.Profiling.Profiler.EndSample();
        }

        {
            UnityEngine.Profiling.Profiler.BeginSample(nameof(dict1000));
            var sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                dict1000.TryGetValue(query1000[i], out var t);
                sum += t != null ? t.value : 0;
            }
            UnityEngine.Profiling.Profiler.EndSample();
        }
    }
}
