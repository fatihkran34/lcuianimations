using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LCUI {
    public class AnimatorProgressorTarget : ProgressorTarget
    {
        [SerializeField]private Animator animator;
        [SerializeField] private string animatorParameter;

        private int hash;

        private void Awake()
        {
            hash = Animator.StringToHash(animatorParameter);
            if (animator==null)
            {
                animator = GetComponent<Animator>();
            }
        }

        public override void SetValue(float value)
        {
            animator.SetFloat(hash, value);
        }
    }
}