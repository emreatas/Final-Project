using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Billboard : MonoBehaviour
    {
        public Transform cam;
        void LateUpdate() {
            transform.LookAt(cam.position + cam.forward);
        }
    }
}