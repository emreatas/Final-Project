using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraSystem
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private Vector3 offset;

        private void Start()
        {
            offset = target.position - transform.position;
        }

        private void LateUpdate()
        {
            transform.position = target.position - offset;
        }
    }
}

