using System.Collections.Generic;
using UnityEngine;

namespace JSONSystem
{
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Characters;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Characters = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ResetJson<T>()
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T element, bool prettyPrint, List<T> dataInJson)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            dataInJson.Clear();
            dataInJson.Add(element);
            wrapper.Characters = dataInJson.ToArray();

            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        public static string ToJson<T>(List<T> element, bool prettyPrint, List<T> dataInJson)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            dataInJson.Clear();
            dataInJson.AddRange(element);
            wrapper.Characters = dataInJson.ToArray();

            return JsonUtility.ToJson(wrapper, prettyPrint);
        }
    }
}