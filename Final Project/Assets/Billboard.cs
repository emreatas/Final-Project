using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Billboard : MonoBehaviour
    {
        private Transform cam;
        void LateUpdate() {
            transform.LookAt(cam.position + cam.forward);
        }
        public void setCameraTransform(Transform cam) {
            this.cam = cam;
        }
    }
}