using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public class ObjectPool<T> where T : Object, IObjectPooled<T>
    {
        private List<T> m_ActiveItems = new List<T>();
        private List<T> m_InactiveItems = new List<T>();

        public int ActiveItemCount => m_ActiveItems.Count;
        public int InactiveItemCount => m_InactiveItems.Count;

        public T GetObject(T prefab)
        {
            return GetObject(prefab, null);
        }

        public T GetObject(T prefab, Transform parent)
        {
            Debug.Log(InactiveItemCount);
            if (InactiveItemCount > 0)
            {
                T pooledObject = m_InactiveItems[0];
                m_InactiveItems.Remove(pooledObject);
                m_ActiveItems.Add(pooledObject);
                pooledObject.SetActive(true);
                return pooledObject;
            }

            return InstansiateObject(prefab, parent);
        }
        
        private T InstansiateObject(T prefab, Transform parent)
        {
            T instanisated = Object.Instantiate(prefab, parent);
            m_ActiveItems.Add(instanisated);
            instanisated.SetPool(this);
            return instanisated;
        }

        public void ReleaseObject(T ob)
        {
            m_ActiveItems.Remove(ob);
            m_InactiveItems.Add(ob);
            ob.SetActive(false);
        }
    }
}