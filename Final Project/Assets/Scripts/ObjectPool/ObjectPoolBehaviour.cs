using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public class ObjectPoolBehaviour<T> : MonoBehaviour, IObjectPooled<T> 
        where  T : Object, IObjectPooled<T>
    {
        private ObjectPool<T> m_Pool;
        
        public void SetPool(ObjectPool<T> pool)
        {
            m_Pool = pool;
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void Release()
        {
            m_Pool.ReleaseObject(this as T);
        }
    }
}