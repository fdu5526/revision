using UnityEngine;
using System;

namespace UnityStandardAssets.Utility{
    public class FollowTargetRoom : MonoBehaviour {

        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);

        private void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}
