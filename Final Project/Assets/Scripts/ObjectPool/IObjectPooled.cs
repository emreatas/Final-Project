using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public interface IObjectPooled<T> where T : Object, IObjectPooled<T>
    {
        public void SetPool(ObjectPool<T> pool);
        public void SetPositionAndRotation(Vector3 position, Quaternion rotation);
        public void SetActive(bool value);

        public void SetParent(Transform parent);
        public void Release();
    }
}