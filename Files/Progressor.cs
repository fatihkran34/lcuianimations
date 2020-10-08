using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace LCUI
{
    public class Progressor : MonoBehaviour
    {
        [SerializeField] private ProgressorTarget[] progressorTargets;

        [SerializeField] private float Time;

        [SerializeField] private Ease Ease;

        private Sequence sequence;

        private float targetVal;

        private float currentVal;

        public void SetValue(float value)
        {
            targetVal = value;

            if (sequence != null && sequence.IsActive())
            {
                sequence.Kill();
            }
            sequence = DOTween.Sequence();
            sequence.Append(DOTween.To(GetCurrentValue, SetCurrentValue, targetVal, Time));
        }



        private float GetCurrentValue()
        {
            return currentVal;
        }

        private void SetCurrentValue(float value)
        {
            currentVal = value;
            for (int i = 0; i < progressorTargets.Length; i++)
            {
                progressorTargets[i].SetValue(value);
            }
        }
    }
}