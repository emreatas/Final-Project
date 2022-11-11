using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraSystem
{
    public class CameraAspect : MonoBehaviour
    {
        void Start()
        {
            Camera.main.aspect = 16f / 9f;
        }
    }

}
