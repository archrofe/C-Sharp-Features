using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    public class SkeletonArcherAnim : MonoBehaviour
    {
        public Animator anim;
        private AIAgent aIAgent;

        void Start()
        {
            aIAgent = GetComponent<AIAgent>();
            // Freeze position on start
            aIAgent.updatePosition = false;
        }

        void Update()
        {
            AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
            if (!state.IsName("spawn"))
            {
                aIAgent.updatePosition = true;
                float moveSpeed = aIAgent.velocity.magnitude;
                anim.SetFloat("MoveSpeed", moveSpeed);
            }

        }
    }
}