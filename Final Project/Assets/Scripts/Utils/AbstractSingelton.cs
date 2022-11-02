using UnityEngine;

namespace Utils
{
    public class AbstractSingelton<T> : MonoBehaviour where T : Component
    {
        private static T m_Instance;

        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    T[] foundObjects = FindObjectsOfType<T>();
                    if (foundObjects.Length > 0)
                    {
                        m_Instance = foundObjects[0];
                    }

                    if (m_Instance == null)
                    {
                        var newObject = new GameObject();
                        var instance = newObject.AddComponent<T>();
                        m_Instance = instance;
                    }
                }

                return m_Instance;
            }
        } 
    }
}