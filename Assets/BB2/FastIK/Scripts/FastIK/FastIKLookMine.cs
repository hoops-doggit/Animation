using UnityEngine;
using System.Collections.Generic;

namespace DitzelGames.FastIK
{
    public class FastIKLookMine : MonoBehaviour
    {
        [Range(0, 1)]
        public float weight;
        public int bonesInChain = 2;
        public List<Transform> bones = new List<Transform>();



        /// <summary>
        /// Look at target
        /// </summary>
        public Transform target;

        /// <summary>
        /// Initial direction
        /// </summary>
        protected List<Vector3> startDirection = new List<Vector3>();

        /// <summary>
        /// Initial Rotation
        /// </summary>
        protected List<Quaternion> startRotation = new List<Quaternion>();



        void Awake()
        {
            if (target == null)
                return;

            bones.Add(this.transform);

            for(int i = 0; i < bonesInChain ; i++)
            {
                bones.Add(bones[i].transform.parent);
                startDirection.Add( target.position - bones[i + 1].transform.position);
                startRotation.Add(bones[i + 1].transform.rotation);
            }            
        }

        void LateUpdate()
        {
            if (target == null)
                return;


            for (int i = 1; i < bones.Count -1; i++)
            {
                Quaternion startRotation2 = bones[i].rotation;
                startDirection[i] = target.position - bones[i].transform.position;
                Quaternion FromTo = Quaternion.FromToRotation(bones[i].forward, (target.position - bones[i].transform.position) / bones.Count) * startRotation2;
                Quaternion qLerped = Quaternion.Lerp(startRotation2, FromTo, 1f / bonesInChain);
                bones[i].transform.rotation = qLerped;
            }

            //bones[0].LookAt(target);

        }
    }
}
